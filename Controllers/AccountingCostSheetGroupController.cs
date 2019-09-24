using System.Collections.Generic;
using AllInOne.Controllers.Base;
using AllInOne.Models.Accounting.CostSheetGroup;
using AllInOne.Models.Todo.Group;
using AllInOne.Models.Todo.List;
using AllInOne.Services.Contract.Accounting;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountingCostSheetGroupController : BaseController
    {
        private readonly ICostSheetGroupLib costSheetGroupLib;

        public AccountingCostSheetGroupController(
        ICostSheetGroupLib costSheetGroupLib
        )
        {
            this.costSheetGroupLib = costSheetGroupLib;
        }

        [HttpPost]
        public IActionResult AddCostSheetGroup([FromBody] AddCostSheetGroupModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = costSheetGroupLib.AddCostSheetGroup(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{costSheetGroupId}")]
        public IActionResult DeleteCostSheetGroup(long costSheetGroupId)
        {
            try
            {
                var result = costSheetGroupLib.DeleteCostSheetGroup(costSheetGroupId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{costSheetGroupId}")]
        public IActionResult EditCostSheetGroup(long costSheetGroupId, [FromBody] EditCostSheetGroupModel model)
        {
            try
            {
                model.Id = costSheetGroupId;
                model.UserId = CurrentUserId;

                var result = costSheetGroupLib.EditCostSheetGroup(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public IActionResult GetAllCostSheetGroups()
        {
            try
            {
                var result = costSheetGroupLib.GetAllCostSheetGroups(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{costSheetGroupId}")]
        public IActionResult GetCostSheetGroup(long costSheetGroupId)
        {
            try
            {
                var result = costSheetGroupLib.GetCostSheetGroup(costSheetGroupId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}