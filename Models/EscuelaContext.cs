using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HolaMundoMVC.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }

        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.Nombre = "Platzi School";
            escuela.AnioDeCreacion = 2005;
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Direccion = "5ta Calle";
            escuela.Ciudad = "Tecpan Guatemala";
            escuela.Pais = "Guatemala";

            //Cargar Cursos de la Escuela
            var cursos = CargarCursos(escuela);

            //x cada curso cargar asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            //x cada curso cargar alumnos
            var alumnos = CargarAlumnos(cursos);

            // x cada curso, x cada asignatura, x cada alumno, carga 5 evaluaciones
            var evaluaciones = CargarEvaluaciones(cursos, asignaturas, alumnos, 5);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
            // modelBuilder.Entity<Evaluacion>().HasData(evaluaciones.ToArray());
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura> {
                            new Asignatura{
                                CursoId = curso.Id,
                                Nombre="Matemáticas"} ,
                            new Asignatura{ CursoId = curso.Id, Nombre="Educación Física"},
                            new Asignatura{ CursoId = curso.Id, Nombre="Castellano"},
                            new Asignatura{ CursoId = curso.Id, Nombre="Ciencias Naturales"},
                            new Asignatura{ CursoId = curso.Id, Nombre="Programación"}

                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas = tmpList;
            }

            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso
                        {
                            EscuelaId = escuela.Id,
                            Nombre = "101",
                            Direccion = "No hay",
                            Jornada = TiposJornada.Mañana
                        },
                        new Curso
                        {
                            EscuelaId = escuela.Id,
                            Nombre = "201",
                            Direccion = "No hay",
                            Jornada = TiposJornada.Mañana
                        },
                        new Curso
                        {
                            EscuelaId = escuela.Id,
                            Nombre = "301",
                            Direccion = "No hay",
                            Jornada = TiposJornada.Mañana
                        },
                        new Curso
                        {
                            EscuelaId = escuela.Id,
                            Nombre = "401",
                            Direccion = "No hay",
                            Jornada = TiposJornada.Tarde
                        },
                        new Curso
                        {
                            EscuelaId = escuela.Id,
                            Nombre = "501",
                            Direccion = "No hay",
                            Jornada = TiposJornada.Tarde
                        },
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso, int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoId = curso.Id,
                                   Nombre = $"{n1} {n2} {a1}"
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<Evaluacion> CargarEvaluaciones(List<Curso> cursos, List<Asignatura> asignaturas, List<Alumno> alumnos, int numeroEvaluaciones = 5)
        {
            Random rnd = new Random();
            var listaEv = new List<Evaluacion>();
            foreach (var curso in cursos)
            {
                foreach (var asignatura in asignaturas)
                {
                    foreach (var alumno in alumnos)
                    {
                        for (int i = 0; i < numeroEvaluaciones; i++)
                        {
                            int cantRandom = rnd.Next(0, 500);
                            var tmp = new List<Evaluacion> {
                                new Evaluacion {
                                    Nombre = "Evaluación de " + asignatura.Nombre + " # " + (i + 1),
                                    AlumnoId = alumno.Id,
                                    Alumno = alumno,
                                    AsignaturaId = asignatura.Id,
                                    Asignatura = asignatura,
                                    Nota = (float)cantRandom/100
                                }
                            };
                            listaEv.AddRange(tmp);
                        }
                    }
                }
            }

            return listaEv;
        }

    }
}