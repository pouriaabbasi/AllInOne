using System.Threading.Tasks;
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
        public async Task<IActionResult> AddGroup([FromBody] AddGroupModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result =await groupLib.AddGroupAsync(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{groupId}")]
        public async Task<GroupModel> EditGroup(long groupId, [FromBody] EditGroupModel model)
        {
            model.UserId = CurrentUserId;

            model.Id = groupId;

            var result =await groupLib.EditGroupAsync(model);

            return result;
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteGroup(long groupId)
        {
            try
            {
                var result = await groupLib.DeleteGroupAsync(groupId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetGroup(long groupId)
        {
            try
            {
                var result = await groupLib.GetGroupAsync(groupId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            try
            {
                var result = await groupLib.GetAllGroupsAsync(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}