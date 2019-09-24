using System.Collections.Generic;
using AllInOne.Models.Accounting.CostSheetGroup;

namespace AllInOne.Services.Contract.Accounting
{
    public interface ICostSheetGroupLib
    {
        CostSheetGroupModel AddCostSheetGroup(AddCostSheetGroupModel model);
        CostSheetGroupModel EditCostSheetGroup(EditCostSheetGroupModel model);
        bool DeleteCostSheetGroup(long costSheetGroupId, long userId);
        CostSheetGroupModel GetCostSheetGroup(long costSheetGroupId, long userId);
        List<CostSheetGroupModel> GetAllCostSheetGroups(long userId);
    }
}