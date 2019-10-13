using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.LeitnerBox.Question;

namespace AllInOne.Services.Contract.LeitnerBox
{
    public interface IQuestionLib
    {
        Task<QuestionModel> AddQuestionAsync(AddQuestionModel model);
        Task<QuestionModel> EditQuestionAsync(EditQuestionModel model, long userId);
        Task<bool> DeleteQuestionAsync(long questionId, long userId);
        Task<QuestionModel> GetQuestionAsync(long questionId, long userId);
        Task<List<QuestionModel>> GetAllQuestionsAsync(long userId);
        Task<bool> ProcessBoxAsync(long boxId, long userId);
        Task<bool> ProcessQuestionAsync(ProcessQuestionModel model, long userId);
        Task<List<QuestionQueModel>> GetQuestionQueAsync(long boxId, long userId);
    }
}