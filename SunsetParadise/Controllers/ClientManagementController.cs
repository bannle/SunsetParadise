using Microsoft.AspNetCore.Mvc;
using SunsetParadise.Models;
using System.Collections.Generic;

namespace SunsetParadise.Controllers
{
    public class ClientManagementController : Controller
    {
        private static List<Client> _clients = new List<Client>
        {
            new Client { Name = "Juan Pérez", DUI = "12345678-9", Phone = "2222-3333" },
            new Client { Name = "María López", DUI = "98765432-1", Phone = "7777-8888" },
            new Client { Name = "Carlos Sánchez", DUI = "11223344-5", Phone = "5555-6666" }
        };

        public IActionResult ClientManagement()
        {
            return View(_clients);
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {
                _clients.Add(client);
            }
            return RedirectToAction("ClientManagement");
        }
    }
}
