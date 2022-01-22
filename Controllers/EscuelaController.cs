using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers
{
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

            escuela.Fundacion = 2004;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";

            return View(escuela);
        }
    }
}