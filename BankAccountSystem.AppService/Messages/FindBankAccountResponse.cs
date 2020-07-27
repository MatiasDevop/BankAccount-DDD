using System;
using System.Collections.Generic;
using System.Text;
using BankAccountSystem.AppService.ViewModel;

namespace BankAccountSystem.AppService.Messages
{
    public class FindBankAccountResponse: ResponseBase
    {
        public BankAccountView BankAccount { get; set; }
    }
}
