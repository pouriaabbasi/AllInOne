using System.Collections.Generic;
using AllInOne.Models.Todo.Group;
using AllInOne.Models.Todo.List;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TodoListController : Controller
    {
        private readonly IListLib listLib;

        public TodoListController(
        IListLib listLib
        )
        {
            this.listLib = listLib;
        }

        [HttpPost]
        public ListModel AddList([FromBody] AddListModel model)
        {
            var result = listLib.AddList(model);

            return result;
        }

        [HttpPut("{listId}/{groupId}")] 
        public bool AddListToGroup(long listId, long groupId)
        {
            var result = listLib.AddListToGroup(listId, groupId);

            return result;
        }

        [HttpDelete("{listId}")]
        public bool DeleteList(long listId)
        {
            var result = listLib.DeleteList(listId);

            return result;
        }

        [HttpPut("{listId}")]
        public ListModel EditList(long listId, [FromBody] EditListModel model)
        {
            model.Id = listId;

            var result = listLib.EditList(model);

            return result;
        }

        [HttpGet]
        public List<ListModel> GetAllList()
        {
            var result = listLib.GetAllList();

            return result;
        }

        [HttpGet("{listId}")]
        public ListModel GetList(long listId)
        {
            var result = listLib.GetList(listId);

            return result;
        }

        [HttpPut("{listId}/{groupId}")]
        public bool RemoveListFromGroup(long listId, long groupId)
        {
            var result = listLib.RemoveListFromGroup(listId, groupId);

            return result;
        }
    }
}