using System;
using System.Collections.Generic;
using System.Linq;
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

        public ItemModel AddItem(AddItemModel model)
        {
            var entity = new Item
            {
                CreatedDate = DateTime.Now,
                ListId = model.ListId,
                Name = model.Name,
                UserId = model.UsesrId
            };

            itemRepo.Add(entity);

            unitOfWork.Commit();

            return ConvertItemToItemModel(entity);
        }

        public bool ChangeItemStatus(long itemId, long userId)
        {
            var entity = itemRepo.First(x => x.Id == itemId);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != userId) throw new Exception("User Doesn't Owner Of Item");

            entity.Completed = !entity.Completed;
            entity.CompletedDate =
                entity.Completed
                    ? (DateTime?)DateTime.Now
                    : null;

            itemRepo.Update(entity);

            unitOfWork.Commit();

            return true;
        }

        public bool DeleteItem(long itemId, long userId)
        {
            var entity = itemRepo.First(x => x.Id == itemId);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != userId) throw new Exception("User Doesn't Owner Of Item");

            itemRepo.Delete(entity);

            unitOfWork.Commit();

            return true;
        }

        public ItemModel EditItem(EditItemModel model)
        {
            var entity = itemRepo.First(x => x.Id == model.Id);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != model.UserId) throw new Exception("User Doesn't Owner Of Item");

            entity.Name = model.Name;

            itemRepo.Update(entity);

            unitOfWork.Commit();

            return ConvertItemToItemModel(entity);
        }

        public List<ItemModel> GetAllItems(long userId)
        {
            return itemRepo.GetQuery()
                .Where(x => x.UserId == userId)
                .OrderBy(x => x.Completed)
                .ThenByDescending(x => x.CreatedDate)
                .Select(ConvertItemToItemModel)
                .ToList();
        }

        public ItemModel GetItem(long itemId, long userId)
        {
            var entity = itemRepo.First(x => x.Id == itemId);
            if (entity == null) throw new Exception("Item Not Exist");

            if (entity.UserId != userId) throw new Exception("User Doesn't Owner Of Item");

            return ConvertItemToItemModel(entity);
        }

        public List<ItemModel> GetListItems(long userId, long listId)
        {
            var isOwner = listRepo.GetQuery()
                .Any(x =>
                    x.Id == listId
                    && x.UserId == userId);
            if (!isOwner) throw new Exception("You can only access to your lists!");

            return itemRepo.GetQuery()
                .Where(x =>
                    x.ListId == listId
                    && x.UserId == userId)
                .OrderBy(x => x.Completed)
                .ThenByDescending(x => x.CreatedDate)
                .Select(ConvertItemToItemModel)
                .ToList();
        }

        public List<ItemModel> GetOrphanItems(long userId)
        {
            return itemRepo.GetQuery()
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