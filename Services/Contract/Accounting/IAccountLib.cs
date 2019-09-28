using System.Collections.Generic;
using AllInOne.Models.Accounting.Account;

namespace AllInOne.Services.Contract.Accounting
{
    public interface IAccountLib
    {
        AccountModel AddAccount(AddAccountModel model);
        AccountModel EditAccount(EditAccountModel model, long userId);
        bool DeleteAccount(long accountId, long userId);
        AccountModel GetAccount(long accountId, long userId);
        List<AccountModel> GetAllAccounts(long userId);
    }
}