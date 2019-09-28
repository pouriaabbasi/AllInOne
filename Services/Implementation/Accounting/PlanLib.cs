using System;
using System.Collections.Generic;
using System.Linq;
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

        public PlanModel AddPlan(AddPlanModel model)
        {
            var entity = new Plan
            {
                Description = model.Description,
                EndDate = model.EndDate,
                Name = model.Name,
                StartDate = model.StartDate,
                UserId = model.UserId
            };

            planRepo.Add(entity);

            unitOfWork.Commit();

            return ConvertEntityToPlanModel(entity);
        }

        public bool DeletePlan(long planId, long userId)
        {
            var entity = planRepo.First(x =>
                x.Id == planId
                && x.UserId == userId);
            if (entity == null) throw new Exception("Plan not exist!");

            planRepo.Delete(entity);

            unitOfWork.Commit();

            return true;
        }

        public PlanModel EditPlan(EditPlanModel model, long userId)
        {
            var entity = planRepo.First(x =>
                x.Id == model.Id
                && x.UserId == userId);
            if (entity == null) throw new Exception("Plan not exist!");

            entity.Description = model.Description;
            entity.EndDate = model.EndDate;
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;

            return ConvertEntityToPlanModel(entity);
        }

        public List<PlanModel> GetAllPlans(long userId)
        {
            return planRepo.GetQuery()
                .Where(x => x.UserId == userId)
                .Select(ConvertEntityToPlanModel)
                .ToList();
        }

        public PlanModel GetPlan(long planId, long userId)
        {
            var entity = planRepo.First(x =>
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