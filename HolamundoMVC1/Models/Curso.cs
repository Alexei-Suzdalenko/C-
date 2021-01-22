using System;
using System.Collections.Generic;


namespace HolamundoMVC1.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        // navegacion hacia sus hijos
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        
        // [Required]
        public string Dirección { get; set; }

        // navegacion hacia el objeto padre
        public string EscuelaId{ get; set; }
        public Escuela Escuela { get; set; }
    }
}