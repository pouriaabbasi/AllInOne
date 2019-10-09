using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Accounting.Plan;

namespace AllInOne.Services.Contract.Accounting
{
    public interface IPlanLib
    {
        Task<PlanModel> AddPlanAsync(AddPlanModel model);
        Task<PlanModel> EditPlanAsync(EditPlanModel model, long userId);
        Task<bool> DeletePlanAsync(long planId, long userId);
        Task<PlanModel> GetPlanAsync(long planId, long userId);
        Task<List<PlanModel>> GetAllPlansAsync(long userId);
    }
}