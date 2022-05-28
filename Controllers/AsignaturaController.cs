using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {
        [Route("Asignatura/Index")]
        [Route("Asignatura/Index/{id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                        var asignatura = from asig in _context.Asignaturas
                                        where asig.Id == id
                                        select asig;

                        return View(asignatura.SingleOrDefault());
            }
            else
            {
               return View("MultiAsignatura", _context.Asignaturas); 
            }
        }

        public IActionResult MultiAsignatura()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", _context.Asignaturas);
        }

        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
           _context = context; 
        }
    }
}