using System.Collections.Generic;
using AllInOne.Models.Todo.Group;
using AllInOne.Services.Contract.Todo;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TodoGroupController : Controller
    {
        private readonly IGroupLib groupLib;

        public TodoGroupController(
        IGroupLib groupLib
        )
        {
            this.groupLib = groupLib;
        }

        [HttpPost]
        public GroupModel AddGroup([FromBody] AddGroupModel model)
        {
            //TODO : fill by current user
            model.UserId = 1;

            var result = groupLib.AddGroup(model);

            return result;
        }

        [HttpPut("{groupId}")]
        public GroupModel EditGroup(long groupId, [FromBody] EditGroupModel model)
        {
            //TODO : fill by current user
            model.UserId = 1;

            model.Id = groupId;

            var result = groupLib.EditGroup(model);

            return result;
        }

        [HttpDelete("{groupId}")]
        public bool DeleteGroup(long groupId)
        {
            //TODO : fill by current user
            var result = groupLib.DeleteGroup(groupId, 1);

            return result;
        }

        [HttpGet("{groupId}")]
        public GroupModel GetGroup(long groupId)
        {
            //TODO : fill by current user
            var result = groupLib.GetGroup(groupId, 1);

            return result;
        }

        [HttpGet]
        public List<GroupModel> GetAllGroups()
        {
            //TODO : fill by current user
            var result = groupLib.GetAllGroups(1);

            return result;
        }
    }
}