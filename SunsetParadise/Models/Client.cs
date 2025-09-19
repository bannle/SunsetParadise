using System.ComponentModel.DataAnnotations;

namespace SunsetParadise.Models
    {
        public class Client
        {
        [Required(ErrorMessage = "El nombre es obligatorio")]
            public string Name { get; set; }
        [Required(ErrorMessage = "El DUI es obligatorio")]
        [MaxLength(10)]
        [RegularExpression(@"^\d{8}-\d{1}$", ErrorMessage = "El DUI debe tener 8 digitos númericos, un guion y 1 digito.")]
            public string DUI { get; set; }
        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [MaxLength(9)]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El teléfono debe tener el formato 2222-2222.")]
        public string Phone { get; set; }
        }
    }
