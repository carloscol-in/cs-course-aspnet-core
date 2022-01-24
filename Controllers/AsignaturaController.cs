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

    public IActionResult Index()
    {
        var asignatura = _context.Asignaturas.FirstOrDefault();

        return View(asignatura);
    }

    public IActionResult MultiAsignatura()
    {
        IEnumerable<Asignatura> asignaturas = _context.Asignaturas;

        return View(asignaturas);
    }
}