using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Data;
using AllInOne.Data.Entity.Accounting;
using AllInOne.Models.Accounting.CostSheetGroup;
using AllInOne.Services.Contract.Accounting;

namespace AllInOne.Services.Implementation.Accounting
{
    public class CostSheetGroupLib : ICostSheetGroupLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<CostSheetGroup> costSheetGroupRepo;
        public CostSheetGroupLib(
            IUnitOfWork unitOfWork,
            IRepository<CostSheetGroup> costSheetGroupRepo)
        {
            this.costSheetGroupRepo = costSheetGroupRepo;
            this.unitOfWork = unitOfWork;
        }

        public CostSheetGroupModel AddCostSheetGroup(AddCostSheetGroupModel model)
        {
            var entity = new CostSheetGroup
            {
                Name = model.Name,
                UserId = model.UserId
            };

            costSheetGroupRepo.Add(entity);

            unitOfWork.Commit();

            return ConvertEntityToCostSheetGroupModel(entity);
        }

        public bool DeleteCostSheetGroup(long costSheetGroupId, long userId)
        {
            var entity = costSheetGroupRepo.First(x => x.Id == costSheetGroupId);
            if (entity == null) throw new Exception("CostSheetGroup not exist!");

            if (entity.UserId != userId) throw new Exception("You don't owner of CostSheetGroup!");

            costSheetGroupRepo.Delete(entity);

            unitOfWork.Commit();

            return true;
        }

        public CostSheetGroupModel EditCostSheetGroup(EditCostSheetGroupModel model)
        {
            var entity = costSheetGroupRepo.First(x => x.Id == model.Id);
            if (entity == null) throw new Exception("CostSheetGroup not exist!");

            if (entity.UserId != model.UserId) throw new Exception("You don't owner of CostSheetGroup!");

            entity.Name = model.Name;

            costSheetGroupRepo.Update(entity);

            unitOfWork.Commit();

            return ConvertEntityToCostSheetGroupModel(entity);
        }

        public List<CostSheetGroupModel> GetAllCostSheetGroups(long userId)
        {
            return costSheetGroupRepo.GetQuery()
                .Where(x => x.UserId == userId)
                .Select(ConvertEntityToCostSheetGroupModel)
                .ToList();
        }

        public CostSheetGroupModel GetCostSheetGroup(long costSheetGroupId, long userId)
        {
            var entity = costSheetGroupRepo.First(x => x.Id == costSheetGroupId);
            if (entity == null) throw new Exception("CostSheetGroup not exist!");

            if (entity.UserId != userId) throw new Exception("You don't owner of CostSheetGroup!");

            return ConvertEntityToCostSheetGroupModel(entity);
        }

        private CostSheetGroupModel ConvertEntityToCostSheetGroupModel(CostSheetGroup entity)
        {
            return new CostSheetGroupModel
            {
                Id = entity.Id,
                Name = entity.Name,
                UserId = entity.UserId
            };
        }
    }
}