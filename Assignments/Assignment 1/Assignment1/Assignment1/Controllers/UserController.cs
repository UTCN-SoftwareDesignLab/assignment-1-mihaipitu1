using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Database;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Models.Validators;
using Assignment1.Service.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private IAdminService adminService;
        public UserController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        public ActionResult Index()
        {
            var users = adminService.GetUsers();
            return View(users);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user, string adminSelect)
        {
            if (adminSelect.Equals(Constants.Roles.ADMIN) && adminSelect != null)
            {
                user.SetRole(GetRoleFromRights(Constants.Roles.ADMIN));
            }
            else
            {
                if (adminSelect.Equals(Constants.Roles.EMPLOYEE))
                {
                    user.SetRole(GetRoleFromRights(Constants.Roles.EMPLOYEE));
                }
            }
            Notification<bool> notifier = adminService.Register(user.GetName(), user.GetUsername(), user.GetPassword(),user.GetRole());
            if (!notifier.GetResult())
            {
                ViewData["Errors"] = notifier.GetErrors();
                return View("Error");
            }
            return RedirectToAction("Index","User");
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = adminService.GetUserById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if(ModelState.IsValid)
            {
                var newUser = new UserBuilder()
                    .SetId(user.GetId())
                    .Build();
                adminService.UpdateUser(newUser, user.Name, user.Username, user.GetPassword());
                return RedirectToAction("Index", "User");
            }

            return StatusCode(400);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = adminService.GetUserById(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            if (ModelState.IsValid)
            {
                bool x = adminService.DeleteUser(user);
                Debug.WriteLine("Delete is: " + x);
                Debug.WriteLine("Id of user is: " + user.GetId());
                return RedirectToAction("Index", "User");
            }
            return StatusCode(404);
        }

        private Role GetRoleFromRights(string role)
        {
            List<Right> rights = new List<Right>();
            if (role == Constants.Roles.ADMIN)
            {
                foreach (var right in Constants.Rights.ADMIN_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            else
            {
                foreach (var right in Constants.Rights.USER_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            return new Role(role, rights);
        }
    }
}