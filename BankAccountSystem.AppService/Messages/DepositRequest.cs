using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.AppService.Messages
{
    public class DepositRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
