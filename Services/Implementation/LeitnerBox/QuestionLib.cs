using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.LeitnerBox;
using AllInOne.Data.Entity.LeitnerBox.Enums;
using AllInOne.Models.LeitnerBox.Question;
using AllInOne.Services.Contract.LeitnerBox;

namespace AllInOne.Services.Implementation.LeitnerBox
{
    public class QuestionLib : IQuestionLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Question> questionRepo;
        private readonly IRepository<QuestionHistory> questionHistoryRepo;

        public QuestionLib(
            IUnitOfWork unitOfWork,
            IRepository<Question> questionRepo,
            IRepository<QuestionHistory> questionHistoryRepo)
        {
            this.unitOfWork = unitOfWork;
            this.questionRepo = questionRepo;
            this.questionHistoryRepo = questionHistoryRepo;
        }
        public async Task<QuestionModel> AddQuestionAsync(AddQuestionModel model)
        {
            var entity = new Question
            {
                BoxId = model.BoxId,
                MainStage = 1,
                Meaning = model.Meaning,
                FailCount = 0,
                SubStage = 1,
                Vocabulary = model.Vocabulary
            };

            await questionRepo.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return ConvertEntityToQuestionModel(entity);
        }

        public async Task<bool> DeleteQuestionAsync(long questionId, long userId)
        {
            var entity = await questionRepo.FirstAsync(x =>
                x.Id == questionId
                && x.Box.UserId == userId);

            if (entity == null) throw new Exception("Item Not Found!");

            questionRepo.Delete(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<QuestionModel> EditQuestionAsync(EditQuestionModel model, long userId)
        {
            var entity = await questionRepo.FirstAsync(x =>
                x.Id == model.Id
                && x.Box.UserId == userId);

            if (entity == null) throw new Exception("Item Not Found!");

            entity.Vocabulary = model.Vocabulary;
            entity.Meaning = model.Meaning;

            await unitOfWork.CommitAsync();

            return ConvertEntityToQuestionModel(entity);
        }

        public async Task<List<QuestionModel>> GetAllQuestionsAsync(long userId)
        {
            return await questionRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x => x.Box.UserId == userId)
                .Select(ConvertEntityToQuestionModel)
                .ToList();
        }

        public async Task<QuestionModel> GetQuestionAsync(long questionId, long userId)
        {
            var entity = await questionRepo.FirstAsync(x =>
               x.Id == questionId
               && x.Box.UserId == userId);

            if (entity == null) throw new Exception("Item Not Found!");

            return ConvertEntityToQuestionModel(entity);
        }

        public async Task<bool> ProcessBoxAsync(long boxId, long userId)
        {
            var hasPendingQuestion = questionRepo.GetQuery()
                .Any(x =>
                    x.BoxId == boxId
                    && x.Box.UserId == userId
                    && x.IsPending);
            if (hasPendingQuestion) throw new Exception("You must answer pending questions befor process box!");

            var result = questionRepo.GetQuery()
                .Where(x =>
                    x.BoxId == boxId
                    && x.Box.UserId == userId
                    && x.IsFinished == false)
                .OrderByDescending(x => x.MainStage)
                .ThenByDescending(x => x.SubStage)
                .Select(x => x);

            foreach (var question in result)
            {
                var maxStage = Math.Pow(question.MainStage, question.MainStage - 1);
                if (question.SubStage == maxStage)
                {
                    question.QuestionHistory.Add(new QuestionHistory
                    {
                        FromMainStage = question.MainStage,
                        FromSubStage = question.SubStage,
                        HistoryActionType = HistoryActionType.ChangeToPending,
                        ToMainStage = question.MainStage,
                        ToSubStage = question.SubStage
                    });
                    question.IsPending = true;
                }
                else
                {
                    question.QuestionHistory.Add(new QuestionHistory
                    {
                        FromMainStage = question.MainStage,
                        FromSubStage = question.SubStage,
                        HistoryActionType = HistoryActionType.AutoNextStage,
                        ToMainStage = question.MainStage,
                        ToSubStage = question.SubStage++
                    });
                }
            }

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> ProcessQuestionAsync(ProcessQuestionModel model, long userId)
        {
            var entity = await questionRepo.FirstAsync(x =>
                x.Id == model.Id
                && x.Box.UserId == userId);
            if (entity == null) throw new Exception("Item Not Found!");

            entity.IsPending = false;

            if (model.IsSuccess)
            {
                if (entity.MainStage == 6)
                    entity.IsFinished = true;
                else
                {
                    entity.QuestionHistory.Add(new QuestionHistory
                    {
                        FromMainStage = entity.MainStage,
                        FromSubStage = entity.SubStage,
                        HistoryActionType = HistoryActionType.Success,
                        ToMainStage = entity.MainStage++,
                        ToSubStage = entity.SubStage = 1
                    });
                }
            }
            else
            {
                entity.FailCount++;
                entity.QuestionHistory.Add(new QuestionHistory
                {
                    FromMainStage = entity.MainStage,
                    FromSubStage = entity.SubStage,
                    HistoryActionType = HistoryActionType.Fail,
                    ToMainStage = entity.MainStage = 1,
                    ToSubStage = entity.SubStage = 1
                });
            }

            await unitOfWork.CommitAsync();

            return true;
        }

        private QuestionModel ConvertEntityToQuestionModel(Question entity)
        {
            return new QuestionModel
            {
                BoxId = entity.BoxId,
                CreateDate = entity.CreateDate,
                FailCount = entity.FailCount,
                Id = entity.Id,
                MainStage = entity.MainStage,
                Meaning = entity.Meaning,
                SubStage = entity.SubStage,
                Vocabulary = entity.Vocabulary,
                IsPending = entity.IsPending
            };
        }
    }
}