using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankAccountSystem.Model;
using BankAccountSystem.Model.Contract;
using Microsoft.EntityFrameworkCore;

namespace BankAccountSystem.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private BankAccountContext context;

        public BankAccountRepository(BankAccountContext ctx)
        {
            context = ctx;
        }

        public void Add(BankAccount bankAccount)
        {
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            updateOrCreateTransaction(bankAccount);
        }

        public IEnumerable<BankAccount> FindAll()
        {
            var result = context.BankAccounts.Include(x => x.Transaction).ToList();
            // to break circular reference
            foreach (BankAccount bankAccount in result)
            {
                if (bankAccount.Transaction != null)
                {
                    foreach (Transaction trs in bankAccount.Transaction)
                    {
                        trs.BankAccount = null;
                    }
                }
            }

            return result;

        }

        public BankAccount FindBy(Guid AccountId)
        {
            return context.BankAccounts.FirstOrDefault(x => x.BankAccountId == AccountId);
        }
        public void Save(BankAccount bankAccount)
        {
            BankAccount account =
                context.BankAccounts.FirstOrDefault(x => x.BankAccountId == bankAccount.BankAccountId);
            account.CustomerRef = bankAccount.CustomerRef;
            account.Balance = bankAccount.Balance;
            context.SaveChanges();
            updateOrCreateTransaction(bankAccount);
        }
        private void updateOrCreateTransaction(BankAccount bankAccount)
        {
            BankAccount account = context.BankAccounts.FirstOrDefault(x=>x.BankAccountId == bankAccount.BankAccountId);
            var currentTrans = context.Transactions.Where(x => x.BankAccount.BankAccountId == bankAccount.BankAccountId)
                .ToList();
            foreach (Transaction trs in currentTrans)
            {
                context.Transactions.Remove(trs);
                context.SaveChanges();
            }

            foreach (Transaction trs in bankAccount.Transaction)
            {
                context.Transactions.Add(trs);
                context.SaveChanges();
            }
        }


    }
}
