using System.Linq;
using System.Collections.Generic;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers;

public class AlumnoController : Controller
{
    private readonly EscuelaContext _context;
    private readonly ILogger<AlumnoController> _logger;

    public AlumnoController(
        ILogger<AlumnoController> logger,
        EscuelaContext context
    )
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var alumno = _context.Alumnos.FirstOrDefault();

        return View(alumno);
    }

    public IActionResult MultiAlumno()
    {
        IEnumerable<Alumno> alumnos = _context.Alumnos;

        return View("MultiAlumno", alumnos);
    }

    private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        var listaAlumnos = from n1 in nombre1
                           from n2 in nombre2
                           from a1 in apellido1
                           select new Alumno { Nombre = $"{n1} {n2} {a1}" };

        return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
    }
}