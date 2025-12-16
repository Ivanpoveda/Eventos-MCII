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
            
            var solicitudesPorPrioridad = _context.SolicitudesSoporte
                .GroupBy(s => s.Prioridad)
                .Select(g => new
                {
                    Prioridad = g.Key,
                    Total = g.Count()
                })
                .ToList();

           
            var participantesPorCategoria = _context.Participantes
                .GroupBy(p => p.CategoriaEvento)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Count()
                })
                .ToList();

            
            ViewBag.SolicitudesPorPrioridad = solicitudesPorPrioridad;
            ViewBag.ParticipantesPorCategoria = participantesPorCategoria;

            return View();
        }
    }
}


