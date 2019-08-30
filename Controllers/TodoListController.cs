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
            //TODO : Fill current user
            model.UserId = 1;

            var result = listLib.AddList(model);

            return result;
        }

        [HttpPut("{listId}/{groupId}")]
        public bool AddListToGroup(long listId, long groupId)
        {
            //TODO : Fill current user

            var result = listLib.AddListToGroup(listId, groupId, 1);

            return result;
        }

        [HttpDelete("{listId}")]
        public bool DeleteList(long listId)
        {
            //TODO : Fill current user

            var result = listLib.DeleteList(listId, 1);

            return result;
        }

        [HttpPut("{listId}")]
        public ListModel EditList(long listId, [FromBody] EditListModel model)
        {
            //TODO : Fill current user
            model.UserId = 1;

            model.Id = listId;

            var result = listLib.EditList(model);

            return result;
        }

        [HttpGet]
        public List<ListModel> GetAllList()
        {
            //TODO : Fill current user
            var result = listLib.GetAllList(1);

            return result;
        }

        [HttpGet("{listId}")]
        public ListModel GetList(long listId)
        {
            //TODO : Fill current user
            var result = listLib.GetList(listId, 1);

            return result;
        }

        [HttpPut("{listId}/{groupId}")]
        public bool RemoveListFromGroup(long listId, long groupId)
        {
            //TODO : Fill current user
            var result = listLib.RemoveListFromGroup(listId, groupId, 1);

            return result;
        }
    }
}