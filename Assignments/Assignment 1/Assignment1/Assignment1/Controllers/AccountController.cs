using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Service.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        // GET: Account1
        public ActionResult Index()
        {
            List<Account> accounts = accountService.GetAccounts();
            return View(accounts);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            var newAccount = new AccountBuilder()
                 .SetId(accountService.GetMaxId() + 1)
                 .SetAmountMoney(account.GetAmountMoney())
                 .SetCreationDate(DateTime.Now)
                 .SetType(account.GetType())
                 .SetClientId(account.GetClientId())
                 .Build();
            accountService.CreateAccount(newAccount);
            return RedirectToAction("Index", "Account");
        }


        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            var account = accountService.GetAccountById(id);
            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Account account)
        {
            if(ModelState.IsValid)
            {
                accountService.DeleteAccount(account);
                return RedirectToAction("Index","Account");
            }
            return StatusCode(404);
        }

        public ActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TransferMoney(int AccountFrom,int AccountTo,double Amount)
        {
            Account accountFrom = accountService.GetAccountById(AccountFrom);
            Account accountTo = accountService.GetAccountById(AccountTo);
            accountService.TransferMoney(accountFrom, Amount, accountTo);
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PayBill(int AccountFrom, double Amount)
        {
            Account account = accountService.GetAccountById(AccountFrom);
            accountService.PayBills(account, Amount);
            return RedirectToAction("Index", "Account");
        }
    }
}