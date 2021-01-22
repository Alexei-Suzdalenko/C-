using System;

namespace HolamundoMVC1.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        // asignatura no tiene hijos
        public System.Collections.Generic.List<Evaluación> Evaluaciones { get; set; } 
        // #####################

        // padre de asignatura
        public string CursoId { get; set; }
        public Curso Curso {get; set;}

    }
}