using System;
using System.Collections.Generic;

namespace HolaMundoMVC.Models;

public class Alumno: ObjetoEscuelaBase
{
    public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
}