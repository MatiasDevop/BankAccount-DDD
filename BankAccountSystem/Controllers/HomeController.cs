using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BankAccountSystem.AppService;
using BankAccountSystem.AppService.Messages;
using BankAccountSystem.AppService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankAccountSystem.Models;

namespace BankAccountSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationBankAccountService _bankService;

        public HomeController(ILogger<HomeController> logger, ApplicationBankAccountService bankService)
        {
            _logger = logger;
            _bankService = bankService;
        }

        public IActionResult Index()
        {
            IList<BankAccountView> accounts = new List<BankAccountView>();
            accounts.Clear();
            FindAllBankAccountResponse responseAll = _bankService.GetAllBankAccounts();
            accounts = responseAll.BankAccountView;
            return View(accounts);
        }

        public ViewResult Edit(Guid bankAccountId)
        {
            FindBankAccountResponse response = _bankService.GetBankAccountBy(bankAccountId);
            BankAccountView accView = response.BankAccount;
            return View(accView);
        }

        public ViewResult Deposit(Guid bankAccountId)
        {
            FindBankAccountResponse response = _bankService.GetBankAccountBy(bankAccountId);
            BankAccountView accView = response.BankAccount;
            return View(accView);
        }

        public ViewResult Transfer(Guid bankAccountId)
        {
            FindBankAccountResponse response = _bankService.GetBankAccountBy(bankAccountId);
            BankAccountView accView = response.BankAccount;
            return View(accView);
        }

        public ViewResult Create() => View("Edit", new BankAccountView());

        [HttpPost]
        public IActionResult Edit(BankAccountView vm)
        {
            if (ModelState.IsValid)
            {
                BankAccountCreateRequest createAccountRequest = new BankAccountCreateRequest();
                createAccountRequest.CustomerName = vm.CustomerRef;
                _bankService.CreateBankAccount(createAccountRequest);
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with the data values
                return View(vm);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
