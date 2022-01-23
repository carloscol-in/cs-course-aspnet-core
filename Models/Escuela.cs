using System;
using System.Collections.Generic;

namespace HolaMundoMVC.Models;

public class Escuela : ObjetoEscuelaBase
{
    public int AnioDeCreacion { get; set; }

    public string Pais { get; set; }
    public string Ciudad { get; set; }

    public string Direccion { get; set; }

    public TiposEscuela TipoEscuela { get; set; }
    public List<Curso> Cursos { get; set; }

    public Escuela(string nombre, int año) => (Nombre, AnioDeCreacion) = (nombre, año);

    public Escuela()
    {
    }

    public override string ToString()
    {
        return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
    }
}
