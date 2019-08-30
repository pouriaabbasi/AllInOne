using System.Collections.Generic;
using System.Linq;
using AllInOne.Data;
using AllInOne.Data.Entity.Todo;
using AllInOne.Models.Todo.Group;
using AllInOne.Services.Contract.Todo;

namespace AllInOne.Services.Implementation.Todo
{
    public class GroupLib : IGroupLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Group> groupRepo;

        public GroupLib(
            IUnitOfWork unitOfWork,
            IRepository<Group> groupRepo
            )
        {
            this.groupRepo = groupRepo;
            this.unitOfWork = unitOfWork;
        }

        public GroupModel AddGroup(AddGroupModel model)
        {
            var entity = new Group
            {
                Name = model.Name,
                UserId = model.UserId
            };

            groupRepo.Add(entity);

            unitOfWork.commit();

            return ConverGroupToGroupModel(entity);
        }

        public GroupModel EditGroup(EditGroupModel model)
        {
            var entity = groupRepo.First(x => x.Id == model.Id);
            if (entity == null) throw new System.Exception("Group Not Exist");

            if (entity.UserId != model.UserId) throw new System.Exception("User Doesn't Owner Of Group");

            entity.Name = model.Name;

            groupRepo.Update(entity);

            unitOfWork.commit();

            return ConverGroupToGroupModel(entity);
        }

        public bool DeleteGroup(long groupId, long userId)
        {
            var entity = groupRepo.First(x => x.Id == groupId);
            if (entity == null) throw new System.Exception("Group Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of Group");

            groupRepo.Delete(entity);

            unitOfWork.commit();

            return true;
        }

        public GroupModel GetGroup(long groupId, long userId)
        {
            var entity = groupRepo.First(x => x.Id == groupId);
            if (entity == null) throw new System.Exception("Group Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of Group");

            return ConverGroupToGroupModel(entity);
        }

        public List<GroupModel> GetAllGroups(long userId)
        {
            return groupRepo.GetQuery()
                .Where(x => x.UserId == userId)
                .Select(ConverGroupToGroupModel)
                .ToList();
        }

        private GroupModel ConverGroupToGroupModel(Group entity)
        {
            return new GroupModel
            {
                Id = entity.Id,
                Name = entity.Name,
                UserId = entity.UserId
            };
        }
    }
}