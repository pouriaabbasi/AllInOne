using System.Threading.Tasks;
using AllInOne.Controllers.Base;
using AllInOne.Models.LeitnerBox.Box;
using AllInOne.Services.Contract.LeitnerBox;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LeitnerBoxBoxController : BaseController
    {
        private readonly IBoxLib boxLib;

        public LeitnerBoxBoxController(
            IBoxLib boxLib
            )
        {
            this.boxLib = boxLib;
        }

        [HttpPost]
        public async Task<IActionResult> AddBox([FromBody] AddBoxModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = await boxLib.AddBoxAsync(model);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{boxId}")]
        public async Task<IActionResult> DeleteBox(long boxId)
        {
            try
            {
                var result = await boxLib.DeleteBoxAsync(boxId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{boxId}")]
        public async Task<IActionResult> EditBox(long boxId, [FromBody] EditBoxModel model)
        {
            try
            {
                model.Id = boxId;

                var result = await boxLib.EditBoxAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBox()
        {
            try
            {
                var result = await boxLib.GetAllBoxAsync(CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{boxId}")]
        public async Task<IActionResult> GetBox(long boxId)
        {
            try
            {
                var result = await boxLib.GetBoxAsync(boxId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}