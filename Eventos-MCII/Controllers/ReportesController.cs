using System.Linq;
using BDEVENTOS.Data;
using BDEVENTOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventSupportManager.Controllers
{
    public class ReportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SolicitudesPorPrioridad =
                _context.SolicitudesSoporte
                .GroupBy(s => s.Prioridad)
                .Select(g => new
                {
                    Prioridad = g.Key,
                    Total = g.Count()
                })
                .ToList();

            ViewBag.ParticipantesPorCategoria =
                _context.Participantes
                .GroupBy(p => p.CategoriaEvento)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Count()
                })
                .ToList();

            return View();
        }
    }
}
