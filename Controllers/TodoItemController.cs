using System.Collections.Generic;
using AllInOne.Models.Todo.Group;
using AllInOne.Models.Todo.Item;
using AllInOne.Models.Todo.List;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TodoItemController : Controller
    {
        private readonly IItemLib itemLib;

        public TodoItemController(
        IItemLib itemLib
        )
        {
            this.itemLib = itemLib;
        }

        [HttpPost]
        public ItemModel AddItem([FromBody]AddItemModel model)
        {
            //TODO: add current user id
            model.UsesrId = 1;

            var result = itemLib.AddItem(model);

            return result;
        }

        [HttpPut("{itemId}")]
        public bool ChangeItemStatus(long itemId)
        {
            //todo: add current user id
            var result = itemLib.ChangeItemStatus(itemId, 1);

            return result;
        }

        [HttpDelete("{itemId}")]
        public bool DeleteItem(long itemId)
        {
            //todo: add current user id
            var result = itemLib.DeleteItem(itemId, 1);

            return result;
        }

        [HttpPut("{itemId}")]
        public ItemModel EditItem(long itemId, [FromBody] EditItemModel model)
        {
            //todo: add current user id
            model.UserId = 1;

            model.Id = itemId;

            var result = itemLib.EditItem(model);

            return result;
        }

        [HttpGet]
        public List<ItemModel> GetAllItems()
        {
            //todo: add current user id
            var result = itemLib.GetAllItems(1);

            return result;
        }

        [HttpGet("{itemId}")]
        public ItemModel GetItem(long itemId)
        {
            //todo: add current user id
            var result = itemLib.GetItem(itemId, 1);

            return result;
        }
    }
}