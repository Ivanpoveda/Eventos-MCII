using System.ComponentModel.DataAnnotations;
namespace BDEVENTOS.Models
{

    public class SolicitudSoporte
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Evento { get; set; }

        [Required(ErrorMessage = "El tipo de equipo es obligatorio.")]
        [Range(1, 999, ErrorMessage = "Debe ingresar un número válido.")]
        public string TipoEquipo { get; set; }

        [Required]
        [RegularExpression("Alta|Media|Baja", ErrorMessage = "La prioridad debe ser Alta, Media o Baja")]
        public string Prioridad { get; set; }
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
    }
}