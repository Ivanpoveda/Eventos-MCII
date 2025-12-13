using BDEVENTOS.Data;
using BDEVENTOS.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Create(Participante participante)
    {
        if (ModelState.IsValid)
        {
            _context.Participantes.Add(participante);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(participante);
    }
}
