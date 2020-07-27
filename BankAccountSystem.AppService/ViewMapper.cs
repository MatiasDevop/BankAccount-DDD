using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BankAccountSystem.AppService.ViewModel;
using BankAccountSystem.Model;

namespace BankAccountSystem.AppService
{
   public class ViewMapper: Profile
    {
        public ViewMapper()
        {
            CreateMap<BankAccount, BankAccountView>();
            CreateMap<Transaction, TransactionView>();
        }
    }
}
