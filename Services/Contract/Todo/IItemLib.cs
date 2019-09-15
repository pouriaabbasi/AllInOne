using System.Collections.Generic;
using AllInOne.Models.Todo.Item;

namespace AllInOne.Services.Contract.Todo
{
    public interface IItemLib
    {
        ItemModel AddItem(AddItemModel model);
        ItemModel EditItem(EditItemModel model);
        bool DeleteItem(long itemId, long userId);
        bool ChangeItemStatus(long itemId, long userId);
        ItemModel GetItem(long itemId, long userId);
        List<ItemModel> GetAllItems(long userId);
        List<ItemModel> GetListItems(long userId, long listId);
        List<ItemModel> GetOrphanItems(long userId);
    }
}