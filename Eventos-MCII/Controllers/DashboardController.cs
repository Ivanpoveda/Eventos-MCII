using BDEVENTOS.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Agrupar solicitudes por prioridad
        var solicitudesPorPrioridad = _context.SolicitudesSoporte
            .GroupBy(s => s.Prioridad)
            .Select(g => new { Prioridad = g.Key, Total = g.Count() })
            .ToList();

        // Agrupar participantes por categoría
        var participantesPorCategoria = _context.Participantes
            .GroupBy(p => p.CategoriaEvento)
            .Select(g => new { Categoria = g.Key, Total = g.Count() })
            .ToList();

        // Pasar datos a la vista
        ViewBag.SolicitudesPorPrioridad = solicitudesPorPrioridad;
        ViewBag.ParticipantesPorCategoria = participantesPorCategoria;

        return View();
    }
}

