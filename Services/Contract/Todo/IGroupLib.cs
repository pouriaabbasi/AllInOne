using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Todo.Group;

namespace AllInOne.Services.Contract.Todo
{
    public interface IGroupLib
    {
        Task<GroupModel> AddGroupAsync(AddGroupModel model);
        Task<GroupModel> EditGroupAsync(EditGroupModel model);
        Task<bool> DeleteGroupAsync(long groupId, long userId);
        Task<GroupModel> GetGroupAsync(long groupId, long userId);
        Task<List<GroupModel>> GetAllGroupsAsync(long userId);
    }
}