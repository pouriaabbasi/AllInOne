using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Controllers.Base;
using AllInOne.Models.Todo.Group;
using AllInOne.Models.Todo.List;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TodoListController : BaseController
    {
        private readonly IListLib listLib;

        public TodoListController(
        IListLib listLib
        )
        {
            this.listLib = listLib;
        }

        [HttpPost]
        public async Task<IActionResult> AddList([FromBody] AddListModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                var result = await listLib.AddListAsync(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{listId}/{groupId}")]
        public async Task<IActionResult> AddListToGroup(long listId, long groupId)
        {
            try
            {
                var result = await listLib.AddListToGroupAsync(listId, groupId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{listId}")]
        public async Task<IActionResult> DeleteList(long listId)
        {
            try
            {
                var result = await listLib.DeleteListAsync(listId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{listId}")]
        public async Task<IActionResult> EditList(long listId, [FromBody] EditListModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                model.Id = listId;

                var result = await listLib.EditListAsync(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            try
            {
                var result = await listLib.GetAllListAsync(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{listId}")]
        public async Task<IActionResult> GetList(long listId)
        {
            try
            {
                var result = await listLib.GetListAsync(listId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{listId}/{groupId}")]
        public async Task<IActionResult> RemoveListFromGroup(long listId, long groupId)
        {
            try
            {
                var result = await listLib.RemoveListFromGroupAsync(listId, groupId, CurrentUserId);

                return CustomResult(result);

            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}