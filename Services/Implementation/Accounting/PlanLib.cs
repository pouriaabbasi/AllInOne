using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.Accounting;
using AllInOne.Models.Accounting.Plan;
using AllInOne.Services.Contract.Accounting;

namespace AllInOne.Services.Implementation.Accounting
{
    public class PlanLib : IPlanLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Plan> planRepo;

        public PlanLib(
            IUnitOfWork unitOfWork,
            IRepository<Plan> planRepo)
        {
            this.planRepo = planRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PlanModel> AddPlanAsync(AddPlanModel model)
        {
            var entity = new Plan
            {
                Description = model.Description,
                EndDate = model.EndDate,
                Name = model.Name,
                StartDate = model.StartDate,
                UserId = model.UserId
            };

            await planRepo.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return ConvertEntityToPlanModel(entity);
        }

        public async Task<bool> DeletePlanAsync(long planId, long userId)
        {
            var entity = await planRepo.FirstAsync(x =>
                x.Id == planId
                && x.UserId == userId);
            if (entity == null) throw new Exception("Plan not exist!");

            planRepo.Delete(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<PlanModel> EditPlanAsync(EditPlanModel model, long userId)
        {
            var entity = await planRepo.FirstAsync(x =>
                x.Id == model.Id
                && x.UserId == userId);
            if (entity == null) throw new Exception("Plan not exist!");

            entity.Description = model.Description;
            entity.EndDate = model.EndDate;
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;

            await unitOfWork.CommitAsync();

            return ConvertEntityToPlanModel(entity);
        }

        public async Task<List<PlanModel>> GetAllPlansAsync(long userId)
        {
            return await planRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x => x.UserId == userId)
                .Select(ConvertEntityToPlanModel)
                .ToList();
        }

        public async Task<PlanModel> GetPlanAsync(long planId, long userId)
        {
            var entity = await planRepo.FirstAsync(x =>
               x.Id == planId
               && x.UserId == userId);
            if (entity == null) throw new Exception("Plan not exist!");

            return ConvertEntityToPlanModel(entity);
        }

        private PlanModel ConvertEntityToPlanModel(Plan entity)
        {
            return new PlanModel
            {
                Description = entity.Description,
                EndDate = entity.EndDate,
                Id = entity.Id,
                Name = entity.Name,
                StartDate = entity.StartDate,
                UserId = entity.UserId
            };
        }
    }
}