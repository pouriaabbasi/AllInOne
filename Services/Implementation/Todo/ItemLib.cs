using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.Todo;
using AllInOne.Models.Todo.Item;
using AllInOne.Services.Contract.Todo;

namespace AllInOne.Services.Implementation.Todo
{
    public class ItemLib : IItemLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Item> itemRepo;
        private readonly IRepository<List> listRepo;

        public ItemLib(
            IUnitOfWork unitOfWork,
            IRepository<Item> itemRepo,
            IRepository<List> listRepo)
        {
            this.unitOfWork = unitOfWork;
            this.itemRepo = itemRepo;
            this.listRepo = listRepo;
        }

        public async Task<ItemModel> AddItemAsync(AddItemModel model)
        {
            var entity = new Item
            {
                CreatedDate = DateTime.Now,
                ListId = model.ListId,
                Name = model.Name,
                UserId = model.UsesrId
            };

            await itemRepo.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return ConvertItemToItemModel(entity);
        }

        public async Task<bool> ChangeItemStatusAsync(long itemId, long userId)
        {
            var entity =await itemRepo.FirstAsync(x => x.Id == itemId);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != userId) throw new Exception("User Doesn't Owner Of Item");

            entity.Completed = !entity.Completed;
            entity.CompletedDate =
                entity.Completed
                    ? (DateTime?)DateTime.Now
                    : null;

            itemRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteItemAsync(long itemId, long userId)
        {
            var entity = await itemRepo.FirstAsync(x => x.Id == itemId);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != userId) throw new Exception("User Doesn't Owner Of Item");

            itemRepo.Delete(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<ItemModel> EditItemAsync(EditItemModel model)
        {
            var entity = await itemRepo.FirstAsync(x => x.Id == model.Id);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != model.UserId) throw new Exception("User Doesn't Owner Of Item");

            entity.Name = model.Name;

            itemRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return ConvertItemToItemModel(entity);
        }

        public async Task<List<ItemModel>> GetAllItemsAsync(long userId)
        {
            return await itemRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Completed)
                .ThenByDescending(x => x.CreatedDate)
                .Select(ConvertItemToItemModel)
                .ToList();
        }

        public async Task<ItemModel> GetItemAsync(long itemId, long userId)
        {
            var entity = await itemRepo.FirstAsync(x => x.Id == itemId);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != userId) throw new Exception("User Doesn't Owner Of Item");

            return ConvertItemToItemModel(entity);
        }

        public async Task<List<ItemModel>> GetListItemsAsync(long userId, long listId)
        {
            var isOwner = await listRepo.GetQuery()
                .ToAsyncEnumerable()
                .Any(x =>
                    x.Id == listId
                    && x.UserId == userId);
            if (!isOwner) throw new Exception("You can only access to your lists!");

            return await itemRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x =>
                    x.ListId == listId
                    && x.UserId == userId)
                .OrderBy(x => x.Completed)
                .ThenByDescending(x => x.CreatedDate)
                .Select(ConvertItemToItemModel)
                .ToList();
        }

        public async Task<List<ItemModel>> GetOrphanItemsAsync(long userId)
        {
            return await itemRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x =>
                    x.UserId == userId
                    && x.ListId == null)
                .OrderBy(x => x.Completed)
                .ThenByDescending(x => x.CreatedDate)
                .Select(ConvertItemToItemModel)
                .ToList();
        }

        private ItemModel ConvertItemToItemModel(Item entity)
        {
            return new ItemModel
            {
                Completed = entity.Completed,
                CompletedDate = entity.CompletedDate,
                CreateDate = entity.CreatedDate,
                Id = entity.Id,
                ListId = entity.ListId,
                ListName = entity.List?.Name,
                Name = entity.Name,
                UserId = entity.UserId
            };
        }
    }
}