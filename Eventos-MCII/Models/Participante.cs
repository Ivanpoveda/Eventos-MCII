using System.ComponentModel.DataAnnotations;
namespace BDEVENTOS.Models 
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
    public string CategoriaEvento { get; set; }

    [Range(0, 120)]
    public int Edad { get; set; }

    [Phone]
    public string Telefono { get; set; }

    [DataType(DataType.Date)]
    [CustomValidation(typeof(Participante), nameof(ValidarFecha))]
    public DateTime FechaRegistro { get; set; }

    public static ValidationResult ValidarFecha(DateTime fecha, ValidationContext context)
    {
        if (fecha > DateTime.Now)
            return new ValidationResult("La fecha no puede ser futura");

        return ValidationResult.Success;
    }
}
}

