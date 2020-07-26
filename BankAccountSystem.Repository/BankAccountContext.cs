using System;
using System.Collections.Generic;
using System.Text;
using BankAccountSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountSystem.Repository
{
    public class BankAccountContext: DbContext
    {
        public BankAccountContext(DbContextOptions<BankAccountContext> options): base(options)
        {
            
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
