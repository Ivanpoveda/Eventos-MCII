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

        // READ
        public IActionResult Index()
        {
            return View(_context.Participantes.ToList());
        }

        // CREATE
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
                participante.FechaRegistro = DateTime.Now; // opcional: registrar fecha automáticamente
                _context.Participantes.Add(participante);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(participante);
        }

        // UPDATE
        public IActionResult Edit(int id)
        {
            var participante = _context.Participantes.Find(id);
            if (participante == null) return NotFound();
            return View(participante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Participante participante)
        {
            if (ModelState.IsValid)
            {
                _context.Participantes.Update(participante);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(participante);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var participante = _context.Participantes.Find(id);
            if (participante == null) return NotFound();
            return View(participante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var participante = _context.Participantes.Find(id);
            if (participante == null) return NotFound();

            _context.Participantes.Remove(participante);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
