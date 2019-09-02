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
                //TODO: add current user id
                model.UsesrId = 1;

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
                //todo: add current user id
                var result = itemLib.ChangeItemStatus(itemId, 1);

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
                //todo: add current user id
                var result = itemLib.DeleteItem(itemId, 1);

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
                //todo: add current user id
                model.UserId = 1;

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
                //todo: add current user id
                var result = itemLib.GetAllItems(1);

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
                //todo: add current user id
                var result = itemLib.GetItem(itemId, 1);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}