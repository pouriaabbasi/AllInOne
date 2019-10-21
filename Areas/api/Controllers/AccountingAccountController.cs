using System.Threading.Tasks;
using AllInOne.Areas.api.Controllers.Base;
using AllInOne.Models.Accounting.Account;
using AllInOne.Services.Contract.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Area("api")]
    [ApiController]
    [Authorize]
    public class AccountingAccountController : BaseController
    {
        private readonly IAccountLib accountLib;

        public AccountingAccountController(
        IAccountLib accountLib
        )
        {
            this.accountLib = accountLib;
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] AddAccountModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = await accountLib.AddAccountAsync(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{accountId}")]
        public async Task<IActionResult> DeleteAccount(long accountId)
        {
            try
            {
                var result = await accountLib.DeleteAccountAsync(accountId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> EditAccount(long accountId, [FromBody] EditAccountModel model)
        {
            try
            {
                model.Id = accountId;

                var result = await accountLib.EditAccountAsync(model, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(long accountId)
        {
            try
            {
                var result = await accountLib.GetAccountAsync(accountId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            try
            {
                var result = await accountLib.GetAllAccountsAsync(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}