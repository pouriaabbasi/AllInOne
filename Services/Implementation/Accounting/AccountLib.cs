using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.Accounting;
using AllInOne.Models.Accounting.Account;
using AllInOne.Services.Contract.Accounting;

namespace AllInOne.Services.Implementation.Accounting
{
    public class AccountLib : IAccountLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Account> accountRepo;
        public AccountLib(
            IUnitOfWork unitOfWork,
            IRepository<Account> accountRepo)
        {
            this.accountRepo = accountRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<AccountModel> AddAccountAsync(AddAccountModel model)
        {
            var entity = new Account
            {
                InitialAmount = model.InitialAmount,
                IsCredit = model.IsCredit,
                IsDebit = model.IsDebit,
                Name = model.Name,
                OveralTotal = model.OveralTotal,
                ParentAccountId = model.ParentAccountId,
                UserId = model.UserId
            };

            await accountRepo.AddAsync(entity);

            await unitOfWork.CommitAsync();

            return ConvertEntityToAccountModel(entity);
        }

        public async Task<bool> DeleteAccountAsync(long accountId, long userId)
        {
            var entity = await accountRepo.FirstAsync(x => x.Id == accountId);
            if (entity == null) throw new Exception("Account not exist!");

            if (entity.UserId != userId) throw new Exception("You can delete only your accounts");

            accountRepo.Delete(entity);

            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<AccountModel> EditAccountAsync(EditAccountModel model, long userId)
        {
            var entity = await accountRepo.FirstAsync(x => x.Id == model.Id);
            if (entity == null) throw new Exception("Account not exist!");

            if (entity.UserId != userId) throw new Exception("You don't owner of account!");

            entity.InitialAmount = model.InitialAmount;
            entity.IsCredit = model.IsCredit;
            entity.IsDebit = model.IsDebit;
            entity.Name = model.Name;
            entity.OveralTotal = model.OveralTotal;

            accountRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return ConvertEntityToAccountModel(entity);
        }

        public async Task<AccountModel> GetAccountAsync(long accountId, long userId)
        {
            var entity = await accountRepo.FirstAsync(x => x.Id == accountId);
            if (entity == null) throw new Exception("Account not exist!");

            if (entity.UserId != userId) throw new Exception("You don't owner of account!");

            return ConvertEntityToAccountModel(entity);
        }

        public async Task<List<AccountModel>> GetAllAccountsAsync(long userId)
        {
            return await accountRepo.GetQuery()
                .ToAsyncEnumerable()
                .Where(x => x.UserId == userId)
                .Select(ConvertEntityToAccountModel)
                .ToList();
        }

        private AccountModel ConvertEntityToAccountModel(Account entity)
        {
            return new AccountModel
            {
                Id = entity.Id,
                InitialAmount = entity.InitialAmount,
                IsCredit = entity.IsCredit,
                IsDebit = entity.IsDebit,
                Name = entity.Name,
                OveralTotal = entity.OveralTotal,
                ParentAccountId = entity.ParentAccountId,
                UserId = entity.UserId
            };
        }
    }
}