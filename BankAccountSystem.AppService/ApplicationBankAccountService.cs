﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BankAccountSystem.AppService.Messages;
using BankAccountSystem.AppService.ViewModel;
using BankAccountSystem.Model;
using BankAccountSystem.Model.Contract;

namespace BankAccountSystem.AppService
{
    public class ApplicationBankAccountService
    {
        private readonly BankAccountService _bankAccountService;
        private readonly IBankAccountRepository _bankRepository;
        private readonly IMapper _mapper;
        public ApplicationBankAccountService(BankAccountService bankAccountService, IBankAccountRepository bankRepository, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public BankAccountCreateResponse CreateBankAccount(BankAccountCreateRequest bankAccountCreateRequest)
        {
            BankAccountCreateResponse bankAccountCreateResponse = new BankAccountCreateResponse();
            BankAccount bankAccount = new BankAccount();
            bankAccount.CustomerRef = bankAccountCreateRequest.CustomerName;
            _bankRepository.Add(bankAccount);
            return bankAccountCreateResponse;
        }

        public void Deposit(DepositRequest depositRequest)
        {
            BankAccount bankAccount = _bankRepository.FindBy(depositRequest.AccountId);
            bankAccount.Deposit(depositRequest.Amount, "");
            _bankRepository.Save(bankAccount);
        }

        public void Withdrawal(WithdrawalRequest withdrawalRequest)
        {
            BankAccount bankAccount = _bankRepository.FindBy(withdrawalRequest.AccountId);
            bankAccount.Withdraw(withdrawalRequest.Amount, "");
            _bankRepository.Save(bankAccount);
        }

        public TransferResponse Transfer(TransferRequest request)
        {
            TransferResponse response= new TransferResponse();
            try
            {
                _bankAccountService.Transfer(request.AccountIdTo, request.AccountIdFrom, request.Amount);
                response.Success = true;
            }
            catch (InsufficientFundsException)
            {
                response.Message = "There is not enough funds in account no: " + request.AccountIdFrom.ToString();
                response.Success = false;
            }

            return response;
        }

        public FindAllBankAccountResponse GetAllBankAccounts()
        {
            FindAllBankAccountResponse findAllBankAccountResponse = new FindAllBankAccountResponse();
            IList<BankAccountView> bankAccountViews = new List<BankAccountView>();
            findAllBankAccountResponse.BankAccountView = bankAccountViews;
            foreach (BankAccount acc in _bankRepository.FindAll())
            {
                bankAccountViews.Add(_mapper.Map<BankAccountView>(acc));

            }

            return findAllBankAccountResponse;
        }

    }
}
