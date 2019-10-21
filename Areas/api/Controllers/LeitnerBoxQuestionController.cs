using System.Threading.Tasks;
using AllInOne.Areas.api.Controllers.Base;
using AllInOne.Models.LeitnerBox.Question;
using AllInOne.Services.Contract.LeitnerBox;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Areas.api.Controllers
{
    // [Route("api/[controller]/[action]")]
    [Route("api/[controller]/[action]")]
    [Area("api")]
    [ApiController]
    [Authorize]
    public class LeitnerBoxQuestionController : BaseController
    {
        private readonly IQuestionLib questionLib;

        public LeitnerBoxQuestionController(
            IQuestionLib questionLib
            )
        {
            this.questionLib = questionLib;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] AddQuestionModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = await questionLib.AddQuestionAsync(model);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{questionId}")]
        public async Task<IActionResult> DeleteQuestion(long questionId)
        {
            try
            {
                var result = await questionLib.DeleteQuestionAsync(questionId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{questionId}")]
        public async Task<IActionResult> EditQuestion(long questionId, [FromBody] EditQuestionModel model)
        {
            try
            {
                model.Id = questionId;

                var result = await questionLib.EditQuestionAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var result = await questionLib.GetAllQuestionsAsync(CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestion(long questionId)
        {
            try
            {
                var result = await questionLib.GetQuestionAsync(questionId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{boxId}")]
        public async Task<IActionResult> ProcessBox(long boxId)
        {
            try
            {
                var result = await questionLib.ProcessBoxAsync(boxId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{boxId}")]
        public async Task<IActionResult> GetQuestionQue(long boxId)
        {
            try
            {
                var result = await questionLib.GetQuestionQueAsync(boxId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProcessQuestion([FromBody] ProcessQuestionModel model)
        {
            try
            {
                var result = await questionLib.ProcessQuestionAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}