using HolamundoMVC1.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System; using System.Linq;

namespace HolamundoMVC1.Controllers
{
    // la ruta es /Asignatura/Index
    
    public class AsignaturaController : Controller
    {
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // return View(new Asignatura{ Id = Guid.NewGuid().ToString(), Nombre = "programacion" });
            return View(_context.Asignaturas.FirstOrDefault());
        }
        
        // https://localhost:5001/Asignatura/MultiAsignatura
        public IActionResult MultiAsignatura()
        {
       //  var listaAsignaturas = new List<Asignatura>(){
       //      new Asignatura{Nombre="Matematicas",  Id = Guid.NewGuid().ToString() },
       //      new Asignatura{Nombre="Matematicas2", Id = Guid.NewGuid().ToString() },
       //      new Asignatura{Nombre="Matematicas3", Id = Guid.NewGuid().ToString() },
       //      new Asignatura{Nombre="Matematicas4", Id = Guid.NewGuid().ToString() }
       //  };

            ViewBag.CosaDinamica =  DateTime.Now;
            return View("MultiAsignatura", _context.Asignaturas);
        }

        // https://localhost:5001/Asignatura/GetFromId
        [Route("Asignatura/GetFromId")]
        [Route("Asignatura/GetFromId/{customId}")]
        public IActionResult  GetFromId(string customId)
        {
            if(!string.IsNullOrWhiteSpace(customId)){
                 var asignatura = from asig in _context.Asignaturas 
                                where asig.Id == customId
                                 select asig;
                 return View("Index", asignatura.Single());
            } else {
                 return View("MultiAsignatura", _context.Asignaturas);
            }
        }
    }
}