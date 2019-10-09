using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Accounting.Account;

namespace AllInOne.Services.Contract.Accounting
{
    public interface IAccountLib
    {
        Task<AccountModel> AddAccountAsync(AddAccountModel model);
        Task<AccountModel> EditAccountAsync(EditAccountModel model, long userId);
        Task<bool> DeleteAccountAsync(long accountId, long userId);
        Task<AccountModel> GetAccountAsync(long accountId, long userId);
        Task<List<AccountModel>> GetAllAccountsAsync(long userId);
    }
}