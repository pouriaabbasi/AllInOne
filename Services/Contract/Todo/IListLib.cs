using System.Collections.Generic;
using AllInOne.Models.Todo.List;

namespace AllInOne.Services.Contract.Todo
{
    public interface IListLib
    {
        ListModel AddList(AddListModel model);
        ListModel EditList(EditListModel model);
        bool DeleteList(long listId);
        bool AddListToGroup(long listId, long groupId);
        bool RemoveListFromGroup(long listId, long groupId);
        ListModel GetList(long listId);
        List<ListModel> GetAllList();
    }
}