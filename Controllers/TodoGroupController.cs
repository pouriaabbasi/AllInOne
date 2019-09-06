using AllInOne.Controllers.Base;
using AllInOne.Models.Todo.Group;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TodoGroupController : BaseController
    {
        private readonly IGroupLib groupLib;

        public TodoGroupController(
        IGroupLib groupLib
        )
        {
            this.groupLib = groupLib;
        }

        [HttpPost]
        public IActionResult AddGroup([FromBody] AddGroupModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = groupLib.AddGroup(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{groupId}")]
        public GroupModel EditGroup(long groupId, [FromBody] EditGroupModel model)
        {
            model.UserId = CurrentUserId;

            model.Id = groupId;

            var result = groupLib.EditGroup(model);

            return result;
        }

        [HttpDelete("{groupId}")]
        public IActionResult DeleteGroup(long groupId)
        {
            try
            {
                var result = groupLib.DeleteGroup(groupId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{groupId}")]
        public IActionResult GetGroup(long groupId)
        {
            try
            {
                var result = groupLib.GetGroup(groupId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }

        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            try
            {
                var result = groupLib.GetAllGroups(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}