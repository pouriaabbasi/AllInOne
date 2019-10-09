using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Todo.Item;

namespace AllInOne.Services.Contract.Todo
{
    public interface IItemLib
    {
        Task<ItemModel> AddItemAsync(AddItemModel model);
        Task<ItemModel> EditItemAsync(EditItemModel model);
        Task<bool> DeleteItemAsync(long itemId, long userId);
        Task<bool> ChangeItemStatusAsync(long itemId, long userId);
        Task<ItemModel> GetItemAsync(long itemId, long userId);
        Task<List<ItemModel>> GetAllItemsAsync(long userId);
        Task<List<ItemModel>> GetListItemsAsync(long userId, long listId);
        Task<List<ItemModel>> GetOrphanItemsAsync(long userId);
    }
}