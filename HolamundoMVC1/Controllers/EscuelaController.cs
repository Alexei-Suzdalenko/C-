using System;
using System.Linq;
using HolamundoMVC1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolamundoMVC1.Controllers
{
    // la ruta es /Escuela/Index
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
         //  var escuela = new Escuela();
         //  escuela.AñoDeCreación = 1951;
         //  escuela.UniqueId = Guid.NewGuid().ToString();
         //  escuela.Nombre = "Platzi Shcool";
         //  escuela.Ciudad = "Santander";
         //  escuela.Pais = "España";
         //  escuela.TipoEscuela = TiposEscuela.Secundaria;
         //  ViewBag.CosaDinamica = "La Monja";

            var escuela = _context.Escuelas.FirstOrDefault();

            return View(escuela);
        }

        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}