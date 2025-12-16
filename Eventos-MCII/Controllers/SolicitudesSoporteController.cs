using BDEVENTOS.Models;
using Eventos_MCII.Data;
using Eventos_MCII.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eventos_MCII.Controllers
{
    public class SolicitudesSoporteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudesSoporteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.SolicitudesSoporte.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SolicitudSoporte solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.SolicitudesSoporte.Add(solicitud);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Solicitud registrada correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }

        public IActionResult Edit(int id)
        {
            var solicitud = _context.SolicitudesSoporte.Find(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SolicitudSoporte solicitud)
        {
            if (id != solicitud.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(solicitud);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Solicitud actualizada correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }

        public IActionResult Delete(int id)
        {
            var solicitud = _context.SolicitudesSoporte.Find(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var solicitud = _context.SolicitudesSoporte.Find(id);
            if (solicitud != null)
            {
                _context.SolicitudesSoporte.Remove(solicitud);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Solicitud eliminada correctamente.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
