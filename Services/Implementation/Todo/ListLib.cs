using System.Collections.Generic;
using System.Linq;
using AllInOne.Data;
using AllInOne.Data.Entity.Todo;
using AllInOne.Models.Todo.List;
using AllInOne.Services.Contract.Todo;

namespace AllInOne.Services.Implementation.Todo
{
    public class ListLib : IListLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<List> listRepo;
        private readonly IRepository<Group> groupRepo;

        public ListLib(
            IUnitOfWork unitOfWork,
            IRepository<List> listRepo,
            IRepository<Group> groupRepo)
        {
            this.listRepo = listRepo;
            this.unitOfWork = unitOfWork;
            this.groupRepo = groupRepo;
        }

        public ListModel AddList(AddListModel model)
        {
            var entity = new List
            {
                Name = model.Name,
                GroupId = model.GroupId,
                UserId = model.UserId
            };

            listRepo.Add(entity);

            unitOfWork.Commit();

            return ConvertListToListModel(entity);
        }

        public bool AddListToGroup(long listId, long groupId, long userId)
        {
            var listEntity = listRepo.First(x => x.Id == listId);
            if (listEntity == null) throw new System.Exception("List Not Exist");

            var groupEntity = groupRepo.First(x => x.Id == groupId);
            if (groupEntity == null) throw new System.Exception("Group Not Exist");

            if (listEntity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            if (groupEntity.UserId != userId) throw new System.Exception("User Doesn't Owner Of Group");

            listEntity.GroupId = groupId;

            listRepo.Update(listEntity);

            unitOfWork.Commit();

            return true;
        }

        public bool DeleteList(long listId, long userId)
        {
            var entity = listRepo.First(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            listRepo.Delete(entity);

            unitOfWork.Commit();

            return true;
        }

        public ListModel EditList(EditListModel model)
        {
            var entity = listRepo.First(x => x.Id == model.Id);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != model.UserId) throw new System.Exception("User Doesn't Owner Of List");


            entity.Name = model.Name;

            listRepo.Update(entity);

            unitOfWork.Commit();

            return ConvertListToListModel(entity);
        }

        public List<ListModel> GetAllList(long userId)
        {
            return listRepo.GetQuery()
                .Where(x => x.UserId == userId)
                .Select(ConvertListToListModel)
                .ToList();
        }

        public ListModel GetList(long listId, long userId)
        {
            var entity = listRepo.First(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            return ConvertListToListModel(entity);
        }

        public bool RemoveListFromGroup(long listId, long groupId, long userId)
        {
            var entity = listRepo.First(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            if (entity.GroupId != groupId) throw new System.Exception("List Doesn't Member Of Group");

            entity.GroupId = null;

            listRepo.Update(entity);

            unitOfWork.Commit();

            return true;
        }

        private ListModel ConvertListToListModel(List entity)
        {
            return new ListModel
            {
                GroupId = entity.GroupId,
                GroupName = entity.Group?.Name,
                Id = entity.Id,
                Name = entity.Name,
                UserId = entity.UserId
            };
        }
    }
}