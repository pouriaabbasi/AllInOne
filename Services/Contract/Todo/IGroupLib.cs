using System.Collections.Generic;
using AllInOne.Models.Todo.Group;

namespace AllInOne.Services.Contract.Todo
{
    public interface IGroupLib
    {
        GroupModel AddGroup(AddGroupModel model);
        GroupModel EditGroup(EditGroupModel model);
        bool DeleteGroup(long groupId);
        GroupModel GetGroup(long groupId);
        List<GroupModel> GetAllGroups();
    }
}