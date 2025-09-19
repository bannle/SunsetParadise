using Microsoft.AspNetCore.Mvc;
using SunsetParadise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SunsetParadise.Controllers { public class ReservationManagementController : Controller {
        private static int _reservationCounter = 4; 
        private static List<Room> _rooms = RoomManagementController.GetRooms(); 
        private static List<Client> _clients = ClientManagementController.GetClients();
        private static List<Reservation> _reservations = new List<Reservation>
        { new Reservation 
        { 
            Id = 1, 
            ClientName = "Juan Pérez", 
            RoomNumber = 101, 
            RoomType = "Habitación individual", 
            RoomPrice = 50, 
            CheckIn = DateTime.Today.AddDays(2), 
            CheckOut = DateTime.Today.AddDays(5), Estado = "Activa" 
        },
            new Reservation
        {
                Id = 2,
                ClientName = "Carlos Sánchez",
                RoomNumber = 102, RoomType = "Habitación doble estándar",
                RoomPrice = 80, CheckIn = DateTime.Today.AddDays(-5),
                CheckOut = DateTime.Today.AddDays(-2), 
            },
            new Reservation
        {
                Id = 2,
                ClientName = "María Gómez",
                RoomNumber = 103, RoomType = "Habitación doble deluxe",
                RoomPrice = 80, CheckIn = DateTime.Today.AddDays(-5),
                CheckOut = DateTime.Today.AddDays(-2), 
            }
    };

        public IActionResult ReservationManagement()
        {
            UpdateReservationStatuses();
            var viewModel = new ReservationViewModel
            {
                Reservations = _reservations,
                Clients = _clients,
                Rooms = _rooms
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddReservation(ReservationViewModel model)
        {
            if (model.CheckIn < DateTime.Today)
                ModelState.AddModelError(nameof(model.CheckIn), "La fecha de entrada no puede ser menor a hoy.");

            if (model.CheckOut < model.CheckIn)
                ModelState.AddModelError(nameof(model.CheckOut), "La fecha de salida no puede ser menor a la fecha de entrada.");

            var room = _rooms.FirstOrDefault(r => r.Number == model.RoomNumber);
            if (room == null || room.Status != "Disponible")
                ModelState.AddModelError(nameof(model.RoomNumber), "La habitación seleccionada no está disponible.");

            if (!ModelState.IsValid)
            {
                model.Clients = _clients;
                model.Rooms = _rooms;
                model.Reservations = _reservations;

                return View("ReservationManagement", model);
            }

            var reservation = new Reservation
            {
                Id = _reservationCounter++,
                ClientName = model.ClientName,
                RoomNumber = model.RoomNumber,
                RoomType = room.Type,
                RoomPrice = room.Price,
                CheckIn = model.CheckIn,
                CheckOut = model.CheckOut,
                Estado = "Activa"
            };

            room.Status = "No Disponible";
            _reservations.Add(reservation);

            return RedirectToAction("ReservationManagement");
        }


        [HttpPost] public IActionResult CancelReservation(int id) { 
            var reservation = _reservations.FirstOrDefault(r => r.Id == id); 
            if (reservation != null && reservation.Estado == "Activa") 
            { 
                reservation.Estado = "Anulada"; 
                var room = _rooms.FirstOrDefault(r => r.Number == reservation.RoomNumber); 
                if (room != null) 
                {
                    room.Status = "Disponible"; 
                } 
            } return RedirectToAction("ReservationManagement"); }
        private void UpdateReservationStatuses() 
        {
            var today = DateTime.Today; 
            foreach (var reservation in _reservations)
            {
                if (reservation.Estado == "Activa" && today > reservation.CheckOut)
                { reservation.Estado = "Finalizada"; 
                    var room = _rooms.FirstOrDefault(r => r.Number == reservation.RoomNumber); 
                    if (room != null) { room.Status = "Disponible"; 
                    } 
                }
            }
        }
    }
}
