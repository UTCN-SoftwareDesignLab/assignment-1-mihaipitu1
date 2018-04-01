using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.Builders;
using Assignment1.Service.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class ClientController : Controller
    {
        private IClientService clientService;
        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }
        //// GET: Client
        public ActionResult Index()
        {
            var clients = clientService.GetClients();
            return View(clients);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            Debug.WriteLine(clientService.GetMaxId());
            var newClient = new ClientBuilder()
                .SetId(clientService.GetMaxId() + 1)
                .SetName(client.GetName())
                .SetAddress(client.GetAddress())
                .Build();
            clientService.CreateClient(newClient);
            return RedirectToAction("Index", "Client");
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var client = clientService.GetClientById((long)id);
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                var newClient = new ClientBuilder()
                    .SetId(client.GetId())
                    .Build();
                //Debug.WriteLine("Name: " + client.GetName() + " Address:" + client.Address);
                clientService.UpdateClient(newClient, client.Name, client.Address);
                return RedirectToAction("Index", "Client");
            }
            return StatusCode(404);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var client = clientService.GetClientById(id);
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Client client)
        {
            if (ModelState.IsValid)
            {
                clientService.DeleteClient(client);
                return RedirectToAction("Index", "Client");
            }
            return StatusCode(404);
        }
    }
}