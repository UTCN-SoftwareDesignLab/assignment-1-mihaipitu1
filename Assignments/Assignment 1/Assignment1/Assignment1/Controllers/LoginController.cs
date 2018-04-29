using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Service.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class LoginController : Controller
    {
        private IAuthenticationService authService;

        public LoginController(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username,string Password)
        {
            Debug.WriteLine("Username={0} ; Password={1}", Username, Password);
            var userNotification = authService.Login(Username, Password);
            if(userNotification.HasErrors() || userNotification.GetResult() == null)
            {
                ViewData["Errors"] = userNotification.GetErrors();
                return View("Error");
            }
            var user = userNotification.GetResult();
            if (user.GetRole().GetRole().Equals(Database.Constants.Roles.EMPLOYEE))
                return RedirectToAction("Index", "Client");
            return RedirectToAction("Index", "User");
        }

        public ActionResult Error(List<string> errors)
        {
            return View();
        }
    }
}