using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<GroupModel> AddGroupAsync(AddGroupModel model)
        {
            var entity = new Group
            {
                Name = model.Name,
                UserId = model.UserId
            };

            await groupRepo.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return ConverGroupToGroupModel(entity);
        }

        public async Task<GroupModel> EditGroupAsync(EditGroupModel model)
        {
            var entity = await groupRepo.FirstAsync(x => x.Id == model.Id);
            if (entity == null) throw new System.Exception("Group Not Exist");

            if (entity.UserId != model.UserId) throw new System.Exception("User Doesn't Owner Of Group");

            entity.Name = model.Name;

            groupRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return ConverGroupToGroupModel(entity);
        }

        public async Task<bool> DeleteGroupAsync(long groupId, long userId)
        {
            var entity = await groupRepo.FirstAsync(x => x.Id == groupId);
            if (entity == null) throw new System.Exception("Group Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of Group");

            groupRepo.Delete(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<GroupModel> GetGroupAsync(long groupId, long userId)
        {
            var entity = await groupRepo.FirstAsync(x => x.Id == groupId);
            if (entity == null) throw new System.Exception("Group Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of Group");

            return ConverGroupToGroupModel(entity);
        }

        public async Task<List<GroupModel>> GetAllGroupsAsync(long userId)
        {
            return await groupRepo.GetQuery()
                .ToAsyncEnumerable()
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