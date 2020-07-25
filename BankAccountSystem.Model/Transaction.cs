using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.Model
{
    public class Transaction
    {
        public decimal Deposit { get; internal set; }
        public decimal Withdrawal { get; internal set; }
        public string Reference
        { get; internal set; }
        public DateTime Date
        { get; internal set; }
        public Transaction(decimal deposit, decimal withdrawal, string reference, DateTime date)
        {
            this.Deposit = deposit;
            this.Withdrawal = withdrawal;
            this.Reference = reference;
            this.Date = date;
        }

        
    }
}
