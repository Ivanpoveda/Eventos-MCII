using Eventos_MCII.Data;
using Eventos_MCII.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eventos_MCII.Controllers
{
    // Controlador encargado de la generación de reportes
    // Aplica consultas LINQ utilizando EF Core
    public class ReportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Reporte: cantidad de solicitudes agrupadas por prioridad
        public IActionResult SolicitudesPorPrioridad()
        {
            var data = _context.SolicitudesSoporte
                .GroupBy(s => s.Prioridad)
                .Select(g => new ReportePrioridadVM
                {
                    Prioridad = g.Key,
                    Total = g.Count()
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            return View(data);
        }
    }
}
