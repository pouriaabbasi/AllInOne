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
                GroupId = model.GroupId
            };

            listRepo.Add(entity);

            unitOfWork.commit();

            return ConvertListToListModel(entity);
        }

        public bool AddListToGroup(long listId, long groupId)
        {
            var listEntity = listRepo.First(x => x.Id == listId);
            if (listEntity == null) throw new System.Exception("List Not Exist");

            var groupEntity = groupRepo.First(x => x.Id == groupId);
            if (groupEntity == null) throw new System.Exception("Group Not Exist");

            listEntity.GroupId = groupId;

            listRepo.Update(listEntity);

            unitOfWork.commit();

            return true;
        }

        public bool DeleteList(long listId)
        {
            var entity = listRepo.First(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            listRepo.Delete(entity);

            unitOfWork.commit();

            return true;
        }

        public ListModel EditList(EditListModel model)
        {
            var entity = listRepo.First(x => x.Id == model.Id);
            if (entity == null) throw new System.Exception("List Not Exist");

            entity.Name = model.Name;

            listRepo.Update(entity);

            unitOfWork.commit();

            return ConvertListToListModel(entity);
        }

        public List<ListModel> GetAllList()
        {
            return listRepo.Get()
                .Select(ConvertListToListModel)
                .ToList();
        }

        public ListModel GetList(long listId)
        {
            var entity = listRepo.First(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            return ConvertListToListModel(entity);
        }

        public bool RemoveListFromGroup(long listId, long groupId)
        {
            var entity = listRepo.First(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.GroupId != groupId) throw new System.Exception("List Doesn't Member Of Group");

            entity.GroupId = null;

            listRepo.Update(entity);

            unitOfWork.commit();

            return true;
        }

        private ListModel ConvertListToListModel(List entity)
        {
            return new ListModel
            {
                GroupId = entity.GroupId,
                GroupName = entity.Group?.Name,
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}