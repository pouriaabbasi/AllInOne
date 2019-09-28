using System;
using System.Collections.Generic;
using System.Linq;
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

        public AccountModel AddAccount(AddAccountModel model)
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

            accountRepo.Add(entity);

            unitOfWork.Commit();

            return ConvertEntityToAccountModel(entity);
        }

        public bool DeleteAccount(long accountId, long userId)
        {
            var entity = accountRepo.First(x => x.Id == accountId);
            if (entity == null) throw new Exception("Account not exist!");

            if (entity.UserId != userId) throw new Exception("You can delete only your accounts");

            accountRepo.Delete(entity);

            unitOfWork.Commit();

            return true;
        }

        public AccountModel EditAccount(EditAccountModel model, long userId)
        {
            var entity = accountRepo.First(x => x.Id == model.Id);
            if (entity == null) throw new Exception("Account not exist!");

            if (entity.UserId != userId) throw new Exception("You don't owner of account!");

            entity.InitialAmount = model.InitialAmount;
            entity.IsCredit = model.IsCredit;
            entity.IsDebit = model.IsDebit;
            entity.Name = model.Name;
            entity.OveralTotal = model.OveralTotal;

            accountRepo.Update(entity);

            unitOfWork.Commit();

            return ConvertEntityToAccountModel(entity);
        }

        public AccountModel GetAccount(long accountId, long userId)
        {
            var entity = accountRepo.First(x => x.Id == accountId);
            if (entity == null) throw new Exception("Account not exist!");

            if (entity.UserId != userId) throw new Exception("You don't owner of account!");

            return ConvertEntityToAccountModel(entity);
        }

        public List<AccountModel> GetAllAccounts(long userId)
        {
            return accountRepo.GetQuery()
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