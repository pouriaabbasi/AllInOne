using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Todo.List;

namespace AllInOne.Services.Contract.Todo
{
    public interface IListLib
    {
        Task<ListModel> AddListAsync(AddListModel model);
        Task<ListModel> EditListAsync(EditListModel model);
        Task<bool> DeleteListAsync(long listId, long userId);
        Task<bool> AddListToGroupAsync(long listId, long groupId, long userId);
        Task<bool> RemoveListFromGroupAsync(long listId, long groupId, long userId);
        Task<ListModel> GetListAsync(long listId, long userId);
        Task<List<ListModel>> GetAllListAsync(long userId);
    }
}