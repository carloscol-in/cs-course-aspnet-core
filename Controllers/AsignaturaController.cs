using System.Collections.Generic;
using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers;

public class AsignaturaController : Controller
{
    private readonly EscuelaContext _context;
    private readonly ILogger<AsignaturaController> _logger;

    public AsignaturaController(
        ILogger<AsignaturaController> logger,
        EscuelaContext context
    )
    {
        _context = context;
        _logger = logger;
    }

    [Route("Asignatura/Index")]
    [Route("Asignatura/Index/{id}")]
    public IActionResult Index(string id)
    {
        if(!string.IsNullOrWhiteSpace(id))
        {
            var asignatura = _context.Asignaturas.Find(id);

            return View(asignatura);
        }
        else
        {
            IEnumerable<Asignatura> asignaturas = _context.Asignaturas;

            return View("MultiAsignatura", asignaturas);
        }
    }

    public IActionResult MultiAsignatura()
    {
        IEnumerable<Asignatura> asignaturas = _context.Asignaturas;

        return View(asignaturas);
    }
}