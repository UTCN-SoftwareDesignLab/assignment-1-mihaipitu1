using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Service.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService savingAccountService;
        private IAccountService spendingAccountService;

        public AccountController(IAccountService savingAccountService, IAccountService spendingAccountService)
        {
            this.savingAccountService = savingAccountService;
            this.spendingAccountService = spendingAccountService;
        }
        // GET: Account
        public ActionResult Index()
        {
            List<Account> savingAccounts = savingAccountService.GetAccounts();
            List<Account> spendingAccounts = spendingAccountService.GetAccounts();
            List<Account> accounts = new List<Account>();
            foreach(Account acc in savingAccounts)
            {
                accounts.Add(acc);
            }
            foreach(Account acc in spendingAccounts)
            {
                accounts.Add(acc);
            }
            return View(accounts);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}