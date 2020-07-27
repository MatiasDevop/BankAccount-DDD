using System;
using System.Collections.Generic;
using System.Text;
using BankAccountSystem.AppService.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankAccountSystem.AppService.Messages
{
    public class FindAllBankAccountResponse : ResponseBase
    {
        public IList<BankAccountView> BankAccountView { get; set; }
    }
}
