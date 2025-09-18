using Microsoft.AspNetCore.Mvc;
using SunsetParadise.Models;
using System.Collections.Generic;
using System.Linq;
namespace SunsetParadise.Controllers
{
    public class RoomManagementController : Controller
    {
        private static List<Room> _rooms = new List<Room>
        {
            new Room { Number = 101, Type = "Habitación individual", Price = 50 },
            new Room { Number = 102, Type = "Habitación doble estándar", Price = 80 },
            new Room { Number = 103, Type = "Habitación doble estándarite", Price = 150 }
        };
        
        public ActionResult RoomManagement()
        {
            return View(_rooms);
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                _rooms.Add(room);
            }
            return RedirectToAction("RoomManagement");
        }

        public IActionResult AvailableRooms()
        {
            var disponibles = _rooms.Where(r => r.Status == "Disponible").ToList();
            return PartialView("_AvailableRooms", disponibles);
        }
    }
}
