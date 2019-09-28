using System.Collections.Generic;
using AllInOne.Models.Accounting.Plan;

namespace AllInOne.Services.Contract.Accounting
{
    public interface IPlanLib
    {
        PlanModel AddPlan(AddPlanModel model);
        PlanModel EditPlan(EditPlanModel model, long userId);
        bool DeletePlan(long planId, long userId);
        PlanModel GetPlan(long planId, long userId);
        List<PlanModel> GetAllPlans(long userId);
    }
}