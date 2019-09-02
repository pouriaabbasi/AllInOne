using System.Collections.Generic;
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
        public IActionResult AddList([FromBody] AddListModel model)
        {
            try
            {
                //TODO : Fill current user
                model.UserId = 1;

                var result = listLib.AddList(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{listId}/{groupId}")]
        public IActionResult AddListToGroup(long listId, long groupId)
        {
            try
            {
                //TODO : Fill current user

                var result = listLib.AddListToGroup(listId, groupId, 1);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{listId}")]
        public IActionResult DeleteList(long listId)
        {
            try
            {
                //TODO : Fill current user

                var result = listLib.DeleteList(listId, 1);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{listId}")]
        public IActionResult EditList(long listId, [FromBody] EditListModel model)
        {
            try
            {
                //TODO : Fill current user
                model.UserId = 1;

                model.Id = listId;

                var result = listLib.EditList(model);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public IActionResult GetAllList()
        {
            try
            {
                //TODO : Fill current user
                var result = listLib.GetAllList(1);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("{listId}")]
        public IActionResult GetList(long listId)
        {
            try
            {
                //TODO : Fill current user
                var result = listLib.GetList(listId, 1);

                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut("{listId}/{groupId}")]
        public IActionResult RemoveListFromGroup(long listId, long groupId)
        {
            try
            {
                //TODO : Fill current user
                var result = listLib.RemoveListFromGroup(listId, groupId, 1);

                return CustomResult(result);

            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}