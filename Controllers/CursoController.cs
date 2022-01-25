using System.Linq;
using System.Collections.Generic;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundoMVC.Controllers;

public class CursoController : Controller
{
    private readonly EscuelaContext _context;
    private readonly ILogger<CursoController> _logger;

    public CursoController(
        ILogger<CursoController> logger,
        EscuelaContext context
    )
    {
        _context = context;
        _logger = logger;
    }

    [Route("Curso/Index")]
    [Route("Curso/Index/{id}")]
    public IActionResult Index(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return MultiCurso();

        var Curso = _context.Cursos.Find(id);
        return View(Curso);
    }

    public IActionResult MultiCurso()
    {
        IEnumerable<Curso> Cursos = _context.Cursos;

        return View("MultiCurso", Cursos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("Create");
    }

    [HttpPost]
    public IActionResult Create(Curso curso)
    {
        var escuela = _context.Escuelas.FirstOrDefault();

        if(escuela == null)
            return View("Error");

        curso.Escuela = escuela;
        curso.EscuelaId = escuela.Id;
        
        if (!ModelState.IsValid)
            return View(curso);
        
        _context.Cursos.Add(curso);
        _context.SaveChanges();

        return View("Index", curso);
    }
}