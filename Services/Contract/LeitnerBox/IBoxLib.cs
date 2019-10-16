using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.LeitnerBox.Box;

namespace AllInOne.Services.Contract.LeitnerBox
{
    public interface IBoxLib
    {
        Task<BoxModel> AddBoxAsync(AddBoxModel model);
        Task<BoxModel> EditBoxAsync(EditBoxModel model, long userId);
        Task<bool> DeleteBoxAsync(long boxId, long userId);
        Task<BoxModel> GetBoxAsync(long boxId, long userId);
        Task<List<BoxModel>> GetAllBoxAsync(long userId);
        Task<BoxStatisticsModel> GetBoxStatisticsAsync(long boxId, long userId);
    }
}