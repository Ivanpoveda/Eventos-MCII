using System;
using System.ComponentModel.DataAnnotations;

namespace Eventos_MCII.Models
{
    public class Participante
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Nombre { get; set; }

        [Required]
        public string Rol { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoriaEvento { get; set; }

        [Range(0, 120)]
        public int Edad { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [CustomValidation(typeof(Participante), nameof(ValidarFecha))]
        public DateTime FechaRegistro { get; set; }

        public static ValidationResult ValidarFecha(DateTime fecha, ValidationContext context)
        {
            return fecha > DateTime.Today
                ? new ValidationResult("La fecha no puede ser futura")
                : ValidationResult.Success;
        }
    }
}
