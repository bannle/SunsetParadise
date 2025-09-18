using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SunsetParadise.Models;

namespace SunsetParadise.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("RoomManagement", "RoomManagement");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ??
           HttpContext.TraceIdentifier
            });
        }

    }
}
