using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SunsetParadise.Models
{
    public class ReservationViewModel
    {
        [Required]
        public string ClientName { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
