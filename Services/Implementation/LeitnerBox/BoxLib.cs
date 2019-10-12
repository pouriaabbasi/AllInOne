using System.Collections.Generic;
using AllInOne.Models.LeitnerBox;
using AllInOne.Services.Contract.LeitnerBox;

namespace AllInOne.Services.Implementation.LeitnerBox
{
    public class BoxLib : IBoxLib
    {
        public BoxModel AddBox(AddBoxModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteBox(long boxId, long userId)
        {
            throw new System.NotImplementedException();
        }

        public BoxModel EditBox(EditBoxModel model, long userId)
        {
            throw new System.NotImplementedException();
        }

        public List<BoxModel> GetAllBox(long userId)
        {
            throw new System.NotImplementedException();
        }

        public BoxModel GetBox(long boxId, long userId)
        {
            throw new System.NotImplementedException();
        }
    }
}