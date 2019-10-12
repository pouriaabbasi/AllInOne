using System.Collections.Generic;
using AllInOne.Models.LeitnerBox;

namespace AllInOne.Services.Contract.LeitnerBox
{
    public interface IBoxLib
    {
        BoxModel AddBox(AddBoxModel model);
        BoxModel EditBox(EditBoxModel model, long userId);
        bool DeleteBox(long boxId, long userId);
        BoxModel GetBox(long boxId, long userId);
        List<BoxModel> GetAllBox(long userId);
    }
}