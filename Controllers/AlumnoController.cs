using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AlumnoController : Controller
    {
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{id}")]
        public IActionResult Index(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                        var alumno = from alumn in _context.Alumnos
                                        where alumn.Id == id
                                        select alumn;

                        return View(alumno.SingleOrDefault());
            }
            else
            {
               return View("MultiAlumno", _context.Alumnos); 
            }
        }

        public IActionResult MultiAlumno()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno", _context.Alumnos);
        }

        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                ViewBag.MensajeExra ="Alumno Creado";
                return View("Index", alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        [Route("Alumno/Edit")]
        [Route("Alumno/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var alumno = from alumn in _context.Alumnos
                            where alumn.Id == id
                            select alumn;

                return View(alumno.SingleOrDefault());
            }
            else
            {
                return View("MultiAlumno", _context.Alumnos);
            }
        }
        
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
           _context = context; 
        }
    }
}