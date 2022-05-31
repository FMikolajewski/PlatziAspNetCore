using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class AsignaturaController : Controller
    {
        #region Index
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
        #endregion
        
        #region MultiAsignatura
        [Route("Asignatura/Multiasignatura")]
        public IActionResult MultiAsignatura()
        {
            ViewBag.CosaDinamica = "La Monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", _context.Asignaturas);
        }
        #endregion

        #region Create
        [Route("Asignatura/Create")]
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            ViewBag.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                _context.Asignaturas.Add(asignatura);
                _context.SaveChanges();
                ViewBag.MensajeExra ="Asignatura Creada";
                return View("Index", asignatura);
            }
            else
            {
                return View(asignatura);
            }
        }
        #endregion

        #region Edit
        [Route("Asignatura/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
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
        #endregion


        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
           _context = context; 
        }
    }
}