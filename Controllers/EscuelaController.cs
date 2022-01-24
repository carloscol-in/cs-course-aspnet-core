using System.Linq;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers;

public class EscuelaController : Controller
{
    private readonly EscuelaContext _context;
    private readonly ILogger<EscuelaController> _logger;

    public EscuelaController(
        ILogger<EscuelaController> logger,
        EscuelaContext context
    )
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var escuela = _context.Escuelas.FirstOrDefault<Escuela>();

        return View(escuela);
    }
}
