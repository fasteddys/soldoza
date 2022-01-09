using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspStudio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ISOLDOZA_MST_GRL_PROYECTOS _proyectos;
        private readonly ISOLDOZA_MST_PLANOS _nplano;

        public ProjectsController(ILogger<ProjectsController> logger, ApplicationDbContext context,
                                    ISOLDOZA_MST_GRL_PROYECTOS proyectos, ISOLDOZA_MST_PLANOS nplano)
        {
            _logger = logger;
            _context = context;
            _proyectos = proyectos;
            _nplano = nplano;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Plans()
        {
            var proyectos = await _proyectos.GetAll();
            var nplano = await _nplano.GetAll();

            ViewBag.proyectlist = proyectos;
            return View(nplano);
        }

        [HttpPost]
        public IActionResult AddNPLAN([FromBody] SOLDOZA_MST_PLANOS nplan)
        {
            if (nplan == null)
            {
                return View("NPLAN");
            }

            bool result = _nplano.Insert(nplan);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added plan" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditNPLAN([FromBody] SOLDOZA_MST_PLANOS nplan)
        {
            if (nplan == null)
            {
                return View("NPLAN");
            }

            bool result = _nplano.Update(nplan);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit plan" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }
    }
}
