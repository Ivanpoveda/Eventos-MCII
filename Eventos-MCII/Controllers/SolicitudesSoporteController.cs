using Microsoft.AspNetCore.Mvc;
using BDEVENTOS.Data;
using BDEVENTOS.Models;

namespace BDEVENTOS.Controllers
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
        public IActionResult Create(SolicitudSoporte solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.SolicitudesSoporte.Add(solicitud);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Solicitud registrada correctamente.";
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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
        public IActionResult DeleteConfirmed(int id)
        {
            var solicitud = _context.SolicitudesSoporte.Find(id);
            if (solicitud != null)
            {
                _context.SolicitudesSoporte.Remove(solicitud);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Solicitud eliminada correctamente.";
            }
            return RedirectToAction("Index");
        }
    }
}

