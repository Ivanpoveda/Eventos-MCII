using System.ComponentModel.DataAnnotations;

public class SolicitudSoporteVM
{
    public int Id { get; set; }

    [Required]
    public string Evento { get; set; }

    [Required]
    public string Recurso { get; set; }

    [Range(1, 100)]
    public int Cantidad { get; set; }

    [Required]
    public string Prioridad { get; set; }
}
