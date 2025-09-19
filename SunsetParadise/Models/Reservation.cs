using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SunsetParadise.Models
{
    public class Reservation : IValidatableObject
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal RoomPrice { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        public string Estado { get; set; } = "Activa";

        public decimal Total => RoomPrice * (decimal)(CheckOut - CheckIn).TotalDays;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckIn.Date < DateTime.Today)
            {
                yield return new ValidationResult(
                    "La fecha de entrada no puede ser menor a la fecha actual.",
                    new[] { nameof(CheckIn) });
            }

            if (CheckOut.Date < CheckIn.Date)
            {
                yield return new ValidationResult(
                    "La fecha de salida no puede ser menor a la fecha de entrada.",
                    new[] { nameof(CheckOut) });
            }
        }
    }
}
