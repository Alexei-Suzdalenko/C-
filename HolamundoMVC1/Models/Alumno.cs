using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HolamundoMVC1.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluación> Evaluaciones { get; set; } 

        // padre del curso
        public string CursoId { get; set; }
        public Curso Curso {get; set;}

        [Required(ErrorMessage = "El nombre de alumno es requerido")]
        [Display(Prompt = "Direccion correspondencia", Name = "Address")]
        [MinLength(11, ErrorMessage = "La longitud minima es de once")]
        public override string Nombre { get; set; }
    }
}