using AllInOne.Controllers.Base;
using AllInOne.Models.Accounting.Account;
using AllInOne.Models.Accounting.Plan;
using AllInOne.Services.Contract.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public IActionResult AddPlan([FromBody] AddPlanModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = planLib.AddPlan(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{planId}")]
        public IActionResult DeletePlan(long planId)
        {
            try
            {
                var result = planLib.DeletePlan(planId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{planId}")]
        public IActionResult EditPlan(long planId, [FromBody] EditPlanModel model)
        {
            try
            {
                model.Id = planId;

                var result = planLib.EditPlan(model, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{planId}")]
        public IActionResult GetPlan(long planId)
        {
            try
            {
                var result = planLib.GetPlan(planId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public IActionResult GetAllPlans()
        {
            try
            {
                var result = planLib.GetAllPlans(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}