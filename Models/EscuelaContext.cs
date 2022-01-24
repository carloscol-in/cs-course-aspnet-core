using Microsoft.EntityFrameworkCore;

namespace HolaMundoMVC.Models;

public class EscuelaContext : DbContext
{
    public DbSet<Escuela> Escuelas { get; set; }
    public DbSet<Asignatura> Asignaturas { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Evaluacion> Evaluaciones { get; set; }

    public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Creacion de escuela
        var escuela = new Escuela();
        escuela.AnioDeCreacion = 2004;
        escuela.Nombre = "Platzi School";
        escuela.TipoEscuela = TiposEscuela.Secundaria;
        escuela.Ciudad = "CDMX";
        escuela.Pais = "Mexico";
        escuela.Direccion = "Una direccion";
        #endregion

        #region Creacion de asignaturas
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
        #endregion

        #region Creacion de alumnos
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        var listaAlumnos = from n1 in nombre1
                           from n2 in nombre2
                           from a1 in apellido1
                           select new Alumno { Nombre = $"{n1} {n2} {a1}" };

        listaAlumnos = listaAlumnos.OrderBy((al) => al.Id).Take(30).ToList();
        #endregion

        modelBuilder.Entity<Escuela>().HasData(escuela);
        modelBuilder.Entity<Asignatura>().HasData(asignaturas);
        modelBuilder.Entity<Alumno>().HasData(listaAlumnos.ToArray());
    }
}