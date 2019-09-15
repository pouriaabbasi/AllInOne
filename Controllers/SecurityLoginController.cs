using AllInOne.Controllers.Base;
using AllInOne.Models.Security;
using AllInOne.Services.Contract.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SecurityLoginController : BaseController
    {
        private readonly IUserLib userLib;

        public SecurityLoginController(IUserLib userLib)
        {
            this.userLib = userLib;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                var result = userLib.Login(model);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            try
            {
                var result = userLib.Register(model);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}