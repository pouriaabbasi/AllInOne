using System.Collections.Generic;
using AllInOne.Models.Todo.List;

namespace AllInOne.Services.Contract.Todo
{
    public interface IListLib
    {
        ListModel AddList(AddListModel model);
        ListModel EditList(EditListModel model);
        bool DeleteList(long listId, long userId);
        bool AddListToGroup(long listId, long groupId, long userId);
        bool RemoveListFromGroup(long listId, long groupId, long userId);
        ListModel GetList(long listId, long userId);
        List<ListModel> GetAllList(long userId);
    }
}