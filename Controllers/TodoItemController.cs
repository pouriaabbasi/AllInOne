using System.Collections.Generic;
using AllInOne.Controllers.Base;
using AllInOne.Models.Todo.Group;
using AllInOne.Models.Todo.Item;
using AllInOne.Models.Todo.List;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public IActionResult AddItem([FromBody]AddItemModel model)
        {
            try
            {
                model.UsesrId = CurrentUserId;

                var result = itemLib.AddItem(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{itemId}")]
        public IActionResult ChangeItemStatus(long itemId)
        {
            try
            {
                var result = itemLib.ChangeItemStatus(itemId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(long itemId)
        {
            try
            {
                var result = itemLib.DeleteItem(itemId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{itemId}")]
        public IActionResult EditItem(long itemId, [FromBody] EditItemModel model)
        {
            try
            {
                model.UserId = CurrentUserId;

                model.Id = itemId;

                var result = itemLib.EditItem(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                var result = itemLib.GetAllItems(CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(long itemId)
        {
            try
            {
                var result = itemLib.GetItem(itemId, CurrentUserId);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}