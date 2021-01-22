using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace HolamundoMVC1.Models
{
    public class EscuelaContext: DbContext
    {
        // es una tabla en la base de datos
         public DbSet<Escuela> Escuelas{get; set;}
         // tabla en la base de datos asignatura   
         public DbSet<Asignatura> Asignaturas{get; set;}
         public DbSet<Alumno> Alumnos{get; set;}
         public DbSet<Curso> Cursos{get; set;}
         public DbSet<Evaluación> Evaluaciónes{get; set;}
         public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options){}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
           base.OnModelCreating(modelBuilder);  
         
           var escuela = new Escuela();
           escuela.AñoDeCreación = 1951;
          // escuela.Id = Guid.NewGuid().ToString();
           escuela.Nombre = "Platzi Shcool";
           escuela.Ciudad = "Santander";
           escuela.Pais = "España";
           escuela.TipoEscuela = TiposEscuela.Secundaria;
         




           // cargar cursos escuela
           var cursos = new List<Curso>(){
              new Curso(){Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "101", Jornada = TiposJornada.Mañana, Dirección = "Avenida siemper viva"},
              new Curso(){Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "103", Jornada = TiposJornada.Mañana, Dirección = "Avenida siemper viva"},
              new Curso(){Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "104", Jornada = TiposJornada.Tarde , Dirección = "Avenida siemper viva"},
              new Curso(){Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "151", Jornada = TiposJornada.Noche , Dirección = "Avenida siemper viva"},
              new Curso(){Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "161", Jornada = TiposJornada.Noche , Dirección = "Avenida siemper viva"},
           };

           // x cada curso cargar asignaturas
           var asignaturas = new List<Asignatura>();
           foreach (var curso in cursos)
           {
              var tmpList = new List<Asignatura>{
                  new Asignatura{Nombre="Matematicas",  Id = Guid.NewGuid().ToString(), CursoId = curso.Id },
                  new Asignatura{Nombre="Matematicas2", Id = Guid.NewGuid().ToString(), CursoId = curso.Id },
                  new Asignatura{Nombre="Matematicas3", Id = Guid.NewGuid().ToString(), CursoId = curso.Id },
                  new Asignatura{Nombre="Matematicas4", Id = Guid.NewGuid().ToString(), CursoId = curso.Id }
               };
               asignaturas.AddRange(tmpList);
               //curso.Asignaturas = tmpList;
           }

           // x cada curso cargar alumnos 
           var listaAlumnos = new List<Alumno>();
            foreach (var curso in cursos)
            {
               var tmp = new List<Alumno>{
                  new Alumno{Nombre="Pete",  Id = Guid.NewGuid().ToString() , CursoId = curso.Id},
                  new Alumno{Nombre="Tomu",  Id = Guid.NewGuid().ToString() , CursoId = curso.Id},
                  new Alumno{Nombre="Killi", Id = Guid.NewGuid().ToString() , CursoId = curso.Id},
                  new Alumno{Nombre="Fukiu", Id = Guid.NewGuid().ToString() , CursoId = curso.Id}
               };
               listaAlumnos.AddRange(tmp);
            }

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(listaAlumnos.ToArray());







         //   modelBuilder.Entity<Asignatura>().HasData(
         //      new Asignatura{Nombre="Matematicas",  Id = Guid.NewGuid().ToString(), CursoId = "1"  },
         //      new Asignatura{Nombre="Matematicas2", Id = Guid.NewGuid().ToString(), CursoId = "12"  },
         //      new Asignatura{Nombre="Matematicas3", Id = Guid.NewGuid().ToString(), CursoId = "13"  },
         //      new Asignatura{Nombre="Matematicas4", Id = Guid.NewGuid().ToString(), CursoId = "14"  }
         //   );
         //   modelBuilder.Entity<Alumno>().HasData(
         //      new Alumno{Nombre="Pete",  Id = Guid.NewGuid().ToString() },
         //      new Alumno{Nombre="Tomu", Id = Guid.NewGuid().ToString()  },
         //      new Alumno{Nombre="Killi", Id = Guid.NewGuid().ToString() },
         //      new Alumno{Nombre="Fukiu", Id = Guid.NewGuid().ToString() }
         //   );
         
         
         
         }
    }
}



