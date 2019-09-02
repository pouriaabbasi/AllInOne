using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AllInOne.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IActionResult CustomResult(object result = null, string message = null)
        {
            return Ok(new
            {
                Type = "Ok",
                Message = message,
                Data = result
            });
        }

        protected IActionResult CustomError(IdentityResult identityResult)
        {
            var error = string.Join(", ", identityResult.Errors
                    .Select(x => x.Description).ToArray());

            return CustomError(error, "ApplicationError", null);
        }

        protected IActionResult CustomError(ModelStateDictionary modelState)
        {
            var error = string.Join(" ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(modelError => modelError.ErrorMessage).ToArray());

            return CustomError(error, "UserError", null);
        }

        protected IActionResult CustomError(Exception exception)
        {
            return CustomError(exception.ToString(), "ApplicationError", null);
        }


        protected IActionResult CustomError(object result, string statusCode)
        {
            return CustomError(null, statusCode, result);
        }


        protected IActionResult CustomError(string error)
        {
            return CustomError(error, "UserError", null);
        }

        private IActionResult CustomError(string error, string statusCode, object result)
        {
            return Ok(new
            {
                Type = statusCode,
                Message = error,
                Data = result
            });
        }
    }
}