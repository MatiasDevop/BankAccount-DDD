using System;
using System.Collections.Generic;
using System.Linq;
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
                //.ForMember(dest =>
                //        dest.Transaction,
                //    opt => opt.MapFrom(src => src.Transaction));
            CreateMap<BankAccountView, BankAccount>();
            CreateMap<Transaction, TransactionView>();
            CreateMap<TransactionView, Transaction>();
        }
    }
}
