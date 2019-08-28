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
            var result = groupLib.AddGroup(model);

            return result;
        }

        [HttpPut("{groupId}")]
        public GroupModel EditGroup(long groupId, [FromBody] EditGroupModel model)
        {
            model.Id = groupId;

            var result = groupLib.EditGroup(model);

            return result;
        }

        [HttpDelete("{groupId}")]
        public bool DeleteGroup(long groupId)
        {
            var result = groupLib.DeleteGroup(groupId);

            return result;
        }

        [HttpGet("{groupId}")]
        public GroupModel GetGroup(long groupId)
        {
            var result = groupLib.GetGroup(groupId);

            return result;
        }

        [HttpGet]
        public List<GroupModel> GetAllGroups()
        {
            var result = groupLib.GetAllGroups();

            return result;
        }
    }
}