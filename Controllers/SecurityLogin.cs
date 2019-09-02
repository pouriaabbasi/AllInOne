using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AllInOne.Controllers.Base;
using AllInOne.Models.Security;
using AllInOne.Services.Contract.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityLogin : BaseController
    {
        private readonly IUserLib userLib;

        public SecurityLogin(IUserLib userLib)
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
    }
}