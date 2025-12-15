using Eventos_MCII.Data;
using Eventos_MCII.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eventos_MCII.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Participantes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Participante participante)
        {
            if (ModelState.IsValid)
            {
                _context.Participantes.Add(participante);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(participante);
        }
    }
}
