using System.Linq;
using System.Collections.Generic;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers;

public class AlumnoController : Controller
{
    private readonly ILogger<AlumnoController> _logger;

    public AlumnoController(ILogger<AlumnoController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Alumno alumno = new Alumno
        {
            Nombre = "Natalia"
        };

        return View(alumno);
    }

    public IActionResult MultiAlumno()
    {
        List<Alumno> alumnos = GenerarAlumnosAlAzar(10);

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

        return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
    }
}