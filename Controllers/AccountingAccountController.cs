using AllInOne.Controllers.Base;
using AllInOne.Models.Accounting.Account;
using AllInOne.Models.Todo.Group;
using AllInOne.Services.Contract.Accounting;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountingAccount : BaseController
    {
        private readonly IAccountLib accountLib;

        public AccountingAccount(
        IAccountLib accountLib
        )
        {
            this.accountLib = accountLib;
        }

        [HttpPost]
        public IActionResult AddAccount([FromBody] AddAccountModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = accountLib.AddAccount(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{accountId}")]
        public IActionResult DeleteAccount(long accountId)
        {
            try
            {
                var result = accountLib.DeleteAccount(accountId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{accountId}")]
        public IActionResult EditAccount(long accountId, [FromBody] EditAccountModel model)
        {
            try
            {
                model.Id = accountId;

                var result = accountLib.EditAccount(model, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{accountId}")]
        public IActionResult GetAccount(long accountId)
        {
            try
            {
                var result = accountLib.GetAccount(accountId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var result = accountLib.GetAllAccounts(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}