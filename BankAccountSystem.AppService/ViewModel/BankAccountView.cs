using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.AppService.ViewModel
{
    public class BankAccountView
    {
        public Guid AccountNo { get; set; }
        public string Balance { get; set; }
        public string CustomerRef { get; set; }
        public IList<TransactionView> Transactions { get; set; }
    }
}
