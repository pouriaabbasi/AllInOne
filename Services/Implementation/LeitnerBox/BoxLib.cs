using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.LeitnerBox;
using AllInOne.Models.LeitnerBox.Box;
using AllInOne.Services.Contract.LeitnerBox;

namespace AllInOne.Services.Implementation.LeitnerBox
{
    public class BoxLib : IBoxLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Box> boxRepo;

        public BoxLib(
            IUnitOfWork unitOfWork,
            IRepository<Box> boxRepo)
        {
            this.boxRepo = boxRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BoxModel> AddBoxAsync(AddBoxModel model)
        {
            var entity = new Box
            {
                Description = model.Description,
                Name = model.Name,
                UserId = model.UserId
            };

            await boxRepo.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return ConvertEntityToBoxModel(entity);
        }

        public async Task<bool> DeleteBoxAsync(long boxId, long userId)
        {
            var entity = await boxRepo.FirstAsync(x =>
                x.Id == boxId
                && x.UserId == userId);

            if (entity == null) throw new Exception("Item Not Found!");

            boxRepo.Delete(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<BoxModel> EditBoxAsync(EditBoxModel model, long userId)
        {
            var entity = await boxRepo.FirstAsync(x =>
                x.Id == model.Id
                && x.UserId == userId);

            if (entity == null) throw new Exception("Item Not Found!");

            entity.Description = model.Description;
            entity.Name = model.Name;

            await unitOfWork.CommitAsync();

            return ConvertEntityToBoxModel(entity);
        }

        public async Task<List<BoxModel>> GetAllBoxAsync(long userId)
        {
            return await boxRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x => x.UserId == userId)
                .Select(ConvertEntityToBoxModel)
                .ToList();
        }

        public async Task<BoxModel> GetBoxAsync(long boxId, long userId)
        {
            var entity = await boxRepo.FirstAsync(x =>
                x.Id == boxId
                && x.UserId == userId);

            if (entity == null) throw new Exception("Item Not Found!");

            return ConvertEntityToBoxModel(entity);
        }


        public async Task<BoxStatisticsModel> GetBoxStatisticsAsync(long boxId, long userId)
        {
            var entity = await boxRepo.FirstAsync(x =>
                x.Id == boxId
                && x.UserId == userId);
            if (entity == null) throw new Exception("Item Not Found!");

            var groupedData = entity.Questions.GroupBy(x => x.MainStage);

            var result = new BoxStatisticsModel
            {
                BoxName = entity.Name,
                AllQuestionCount = entity.Questions.Count,
                ReadyForTestCount = entity.Questions.Count(x => x.IsPending),
                CompeletedQuestionCount = entity.Questions.Count(x => x.IsFinished),
                FailCount = entity.Questions.Sum(x => x.FailCount),
                Labels = groupedData.OrderBy(x=>x.Key).Select(x => $"Stage {x.Key}").ToList(),
                Counts = groupedData.OrderBy(x=>x.Key).Select(x => x.Count()).ToList()
            };

            return result;
        }

        private BoxModel ConvertEntityToBoxModel(Box entity)
        {
            return new BoxModel
            {
                Description = entity.Description,
                Id = entity.Id,
                Name = entity.Name,
                UserId = entity.UserId
            };
        }
    }
}