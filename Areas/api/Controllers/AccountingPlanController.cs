using System.Threading.Tasks;
using AllInOne.Areas.api.Controllers.Base;
using AllInOne.Models.Accounting.Plan;
using AllInOne.Services.Contract.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Areas.api.Controllers
{
    // [Route("api/[controller]/[action]")]
    [Route("api/[controller]/[action]")]
    [Area("api")]
    [ApiController]
    [Authorize]
    public class AccountingPlanController : BaseController
    {
        private readonly IPlanLib planLib;

        public AccountingPlanController(
            IPlanLib planLib
        )
        {
            this.planLib = planLib;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlan([FromBody] AddPlanModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = await planLib.AddPlanAsync(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{planId}")]
        public async Task<IActionResult> DeletePlan(long planId)
        {
            try
            {
                var result = await planLib.DeletePlanAsync(planId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{planId}")]
        public async Task<IActionResult> EditPlan(long planId, [FromBody] EditPlanModel model)
        {
            try
            {
                model.Id = planId;

                var result = await planLib.EditPlanAsync(model, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{planId}")]
        public async Task<IActionResult> GetPlan(long planId)
        {
            try
            {
                var result = await planLib.GetPlanAsync(planId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            try
            {
                var result = await planLib.GetAllPlansAsync(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}