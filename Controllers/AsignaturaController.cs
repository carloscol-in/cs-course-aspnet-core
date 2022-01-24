using System.Collections.Generic;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers;

public class AsignaturaController : Controller
{
    private readonly ILogger<AsignaturaController> _logger;

    public AsignaturaController(ILogger<AsignaturaController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Asignatura asignatura = new Asignatura
        {
            Nombre = "Matematicas"
        };

        return View(asignatura);
    }

    public IActionResult MultiAsignatura()
    {
        List<Asignatura> asignaturas = new List<Asignatura>{
            new Asignatura
            {
                Nombre = "Matematicas"
            },
            new Asignatura
            {
                Nombre = "Programacion"
            },
            new Asignatura
            {
                Nombre = "Fisica"
            },
            new Asignatura
            {
                Nombre = "Ingles"
            },
        };

        return View(asignaturas);
    }
}