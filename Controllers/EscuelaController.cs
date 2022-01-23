using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers;

public class EscuelaController : Controller
{
    private readonly ILogger<EscuelaController> _logger;

    public EscuelaController(ILogger<EscuelaController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var escuela = new Escuela();

        escuela.AnioDeCreacion = 2004;
        escuela.Nombre = "Platzi School";
        escuela.TipoEscuela = TiposEscuela.Secundaria;
        escuela.Ciudad = "CDMX";
        escuela.Pais = "Mexico";
        escuela.Direccion = "Una direccion";

        return View(escuela);
    }
}
