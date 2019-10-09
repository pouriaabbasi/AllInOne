using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ListModel> AddListAsync(AddListModel model)
        {
            var entity = new List
            {
                Name = model.Name,
                GroupId = model.GroupId,
                UserId = model.UserId
            };

            await listRepo.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return ConvertListToListModel(entity);
        }

        public async Task<bool> AddListToGroupAsync(long listId, long groupId, long userId)
        {
            var listEntity = await listRepo.FirstAsync(x => x.Id == listId);
            if (listEntity == null) throw new System.Exception("List Not Exist");

            var groupEntity = await groupRepo.FirstAsync(x => x.Id == groupId);
            if (groupEntity == null) throw new System.Exception("Group Not Exist");

            if (listEntity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            if (groupEntity.UserId != userId) throw new System.Exception("User Doesn't Owner Of Group");

            listEntity.GroupId = groupId;

            listRepo.Update(listEntity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteListAsync(long listId, long userId)
        {
            var entity = await listRepo.FirstAsync(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            listRepo.Delete(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<ListModel> EditListAsync(EditListModel model)
        {
            var entity = await listRepo.FirstAsync(x => x.Id == model.Id);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != model.UserId) throw new System.Exception("User Doesn't Owner Of List");


            entity.Name = model.Name;

            listRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return ConvertListToListModel(entity);
        }

        public async Task<List<ListModel>> GetAllListAsync(long userId)
        {
            return await listRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x => x.UserId == userId)
                .Select(ConvertListToListModel)
                .ToList();
        }

        public async Task<ListModel> GetListAsync(long listId, long userId)
        {
            var entity = await listRepo.FirstAsync(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            return ConvertListToListModel(entity);
        }

        public async Task<bool> RemoveListFromGroupAsync(long listId, long groupId, long userId)
        {
            var entity = await listRepo.FirstAsync(x => x.Id == listId);
            if (entity == null) throw new System.Exception("List Not Exist");

            if (entity.UserId != userId) throw new System.Exception("User Doesn't Owner Of List");

            if (entity.GroupId != groupId) throw new System.Exception("List Doesn't Member Of Group");

            entity.GroupId = null;

            listRepo.Update(entity);

            await unitOfWork.CommitAsync();

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