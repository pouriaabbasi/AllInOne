using System.Threading.Tasks;
using AllInOne.Areas.api.Controllers.Base;
using AllInOne.Models.Todo.Item;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Areas.api.Controllers
{
    // [Route("api/[controller]/[action]")]
    [Route("api/[controller]/[action]")]
    [Area("api")]
    [ApiController]
    [Authorize]
    public class TodoItemController : BaseController
    {
        private readonly IItemLib itemLib;

        public TodoItemController(
        IItemLib itemLib
        )
        {
            this.itemLib = itemLib;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody]AddItemModel model)
        {
            try
            {
                model.UsesrId = CurrentUserId;

                var result = await itemLib.AddItemAsync(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> ChangeItemStatus(long itemId)
        {
            try
            {
                var result = await itemLib.ChangeItemStatusAsync(itemId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteItem(long itemId)
        {
            try
            {
                var result = await itemLib.DeleteItemAsync(itemId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> EditItem(long itemId, [FromBody] EditItemModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                model.Id = itemId;

                var result = await itemLib.EditItemAsync(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var result = await itemLib.GetAllItemsAsync(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetItem(long itemId)
        {
            try
            {
                var result = await itemLib.GetItemAsync(itemId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{listId}")]
        public async Task<IActionResult> GetListItems(long listId)
        {
            try
            {
                var result = await itemLib.GetListItemsAsync(CurrentUserId, listId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrphanItems()
        {
            try
            {
                var result = await itemLib.GetOrphanItemsAsync(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}