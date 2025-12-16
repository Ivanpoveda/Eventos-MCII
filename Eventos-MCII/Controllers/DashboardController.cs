using Eventos_MCII.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eventos_MCII.Controllers
{
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
                .Select(g => new
                {
                    Prioridad = g.Key,
                    Total = g.Count()
                })
                .ToList();

<<<<<<< HEAD

        ViewBag.SolicitudesPorPrioridad = solicitudesPorPrioridad;
        ViewBag.ParticipantesPorCategoria = participantesPorCategoria;
=======
            // Agrupar participantes por categoría
            var participantesPorCategoria = _context.Participantes
                .GroupBy(p => p.CategoriaEvento)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Count()
                })
                .ToList();
>>>>>>> ac939e7c8312f7391b0d938554a45548d8f0f79e

            // Pasar datos a la vista
            ViewBag.SolicitudesPorPrioridad = solicitudesPorPrioridad;
            ViewBag.ParticipantesPorCategoria = participantesPorCategoria;

            return View();
        }
    }
}


