using HolamundoMVC1.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System; using System.Linq;

namespace HolamundoMVC1.Controllers
{
    // la ruta es /Alumno/Index
    
    public class AlumnoController : Controller
    {
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{id}")]
        public IActionResult Index(string id)
        {
          //  return View(new Alumno{ Id = Guid.NewGuid().ToString(), Nombre = "First Alumno" });
             if(!string.IsNullOrWhiteSpace(id)){
                 var alumno = from alumn in _context.Alumnos 
                                where alumn.Id == id
                                 select alumn;
                 return View(alumno.Single());
            } else {
                 return View("MultiAlumno", _context.Alumnos);
            }
        }
        
        // https://localhost:5001/Alumno/MultiAlumno
        public IActionResult MultiAlumno()
        {
        //  var listaAlumno = new List<Alumno>(){
        //      new Alumno{Nombre="Pete",  Id = Guid.NewGuid().ToString() },
        //      new Alumno{Nombre="Tomu", Id = Guid.NewGuid().ToString() },
        //      new Alumno{Nombre="Killi", Id = Guid.NewGuid().ToString() },
        //      new Alumno{Nombre="Fukiu", Id = Guid.NewGuid().ToString() }
        //  };

            ViewBag.CosaDinamica =  DateTime.Now;

            return View("MultiAlumno", _context.Alumnos);
        }

        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }


        // https://localhost:5001/Alumno/Create
        public IActionResult Create()
        {
            ViewBag.CosaDinamica =  DateTime.Now;

            return View("Create");
        }

        // if exist post request ?¿!
        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.CosaDinamica =  DateTime.Now;
            
            if(ModelState.IsValid){
                var curso = _context.Cursos.FirstOrDefault();
                alumno.CursoId = curso.Id;
            
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();

                ViewBag.MensageExtra =  "Vista creada";

                return View("Index", alumno);
            } else {
                return View(alumno);
            }
            
        }
    }
}