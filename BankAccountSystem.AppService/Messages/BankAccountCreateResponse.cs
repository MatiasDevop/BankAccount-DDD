using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.AppService.Messages
{
    public class BankAccountCreateResponse : ResponseBase
    {
        public Guid BankAccountId { get; set; }
    }
}
