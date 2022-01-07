using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Infraestructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspStudio.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ISOLDOZA_MST_GRL_CLIENTES _clientes;
        private readonly ISOLDOZA_MST_PAIS _paises;
        private readonly ISOLDOZA_MST_TIPO_DOCUMENTO _tipodocumentos;
        private readonly ISOLDOZA_MST_GRL_PROYECTOS _proyectos;
        private readonly ISOLDOZA_MST_GRL_CONTACTOS _contactos;
        private readonly ISOLDOZA_MST_TIPO_CONTACTO _tipocontacto;
        private readonly ISOLDOZA_MST_CONTACTOS_PROYECTO _contactosproyecto;
        private readonly ISOLDOZA_MST_MATERIALES _materiales;
        private readonly ISOLDOZA_MST_ZONAS _zonas;
        private readonly ISOLDOZA_ADM_MST_LADOS _lados;
        private readonly ISOLDOZA_MST_RESULT_END _rends;
        private readonly ISOLDOZA_MST_POS_SOLDEO _posol;

        public ManagementController(ILogger<HomeController> logger, ApplicationDbContext context,
                                    ISOLDOZA_MST_GRL_CLIENTES clientes, ISOLDOZA_MST_PAIS paises, ISOLDOZA_MST_TIPO_DOCUMENTO tipodocumentos,
                                    ISOLDOZA_MST_GRL_PROYECTOS proyectos, ISOLDOZA_MST_GRL_CONTACTOS contactos, ISOLDOZA_MST_TIPO_CONTACTO tipocontacto,
                                    ISOLDOZA_MST_CONTACTOS_PROYECTO contactosproyecto, ISOLDOZA_MST_MATERIALES materiales, ISOLDOZA_MST_ZONAS zonas, 
                                    ISOLDOZA_ADM_MST_LADOS lados, ISOLDOZA_MST_RESULT_END rends, ISOLDOZA_MST_POS_SOLDEO posol)
        {
            _logger = logger;
            _context = context;
            _clientes = clientes;
            _paises = paises;
            _tipodocumentos = tipodocumentos;
            _proyectos = proyectos;
            _contactos = contactos;
            _tipocontacto = tipocontacto;
            _contactosproyecto = contactosproyecto;
            _materiales = materiales;
            _zonas = zonas;
            _lados = lados;
            _rends = rends;
            _posol = posol;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Customers()
        {
            var customers = _clientes.GetAll2();
            var countries = _paises.GetAll();
            var typesDocuments = await _tipodocumentos.GetAll();


            ViewBag.countriesList = countries;
            ViewBag.typeDocumentsList = typesDocuments;
            return View(customers);
        }

        public async Task<IActionResult> Projects()
        {
            var projects = await _proyectos.GetAll();
            var customers = await _clientes.GetAll();

            ViewBag.customersList = customers;
            return View(projects);
        }

        public async Task<IActionResult> Contacts()
        {
            var contacts = await _contactos.GetAll();
            var customers = await _clientes.GetAll();

            ViewBag.customersList = customers;
            return View(contacts);
        }

        public async Task<IActionResult> Materials()
        {
            var materials = await _materiales.GetAll();
            return View(materials);
        }
        public  IActionResult Zones()
        {
            var zone = _zonas.GetAll();
            return View(zone);
        }
        public IActionResult Sides()
        {
            var side = _lados.GetAll();
            return View(side);
        }
        public IActionResult REnds()
        {
            var rend = _rends.GetAll();
            return View(rend);
        }
        public IActionResult PosSol()
        {
            var posol =_posol.GetAll();
            return View(posol);
        }


        [HttpPost]
        public IActionResult AddCustomer([FromBody] SOLDOZA_MST_GRL_CLIENTES customer)
        {
            var originalSynchronizationContext = SynchronizationContext.Current;

            customer.usuario_creacion = "admin";

            if (!ModelState.IsValid)
            {
                return View("Customers");
            }

            try
            {
                SynchronizationContext.SetSynchronizationContext(null);

                _clientes.Insert(customer);
                return Json(new { exito = true, mensaje = "Successfully added customer" });

            }

            catch
            {
                return Json(new { exito = false, mensaje = "Error" });
            }

            finally
            {
                SynchronizationContext.SetSynchronizationContext(originalSynchronizationContext);
            }

        }

        [HttpPost]
        public IActionResult EditCustomer([FromBody] SOLDOZA_MST_GRL_CLIENTES customer)
        {
            var originalSynchronizationContext = SynchronizationContext.Current;

            customer.usuario_actualizacion = "admin";

            if (!ModelState.IsValid)
            {
                return View("Customers");
            }

            try
            {
                SynchronizationContext.SetSynchronizationContext(null);

                _clientes.Update(customer);
                return Json(new { exito = true, mensaje = "Successfully edit customer" });

            }

            catch
            {
                return Json(new { exito = false, mensaje = "Error" });
            }

            finally
            {
                SynchronizationContext.SetSynchronizationContext(originalSynchronizationContext);
            }

        }

        public async Task<IActionResult> CustomerContacts(int id)
        {
            var customer = await _clientes.GetCustomer(id);
            var contacts = await _contactos.GetAll(id);


            if (customer == null)
            {
                return NotFound();
            }

            ViewBag.contacts = contacts;

            return View(customer);
        }

        public async Task<IActionResult> CustomerProjects(int id)
        {
            var customers = _clientes.GetAll2();
            SOLDOZA_MST_GRL_CLIENTES customer = customers.Where(c => c.id == id).FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            var projects = await _proyectos.GetProjects(id);
            List<SOLDOZA_MST_GRL_PROYECTOS> ListProjects = projects.ToList();

            var typecontact = await _tipocontacto.GetAll();
            var contacts = await _contactos.GetAll(id);


            ViewBag.projects = ListProjects;
            ViewBag.typecontactList = typecontact;
            ViewBag.contactList = contacts;

            return View(customer);
        }

        public async Task<IActionResult> ProjectContacts(int id)
        {
            var projects = await _proyectos.GetProject(id);
            SOLDOZA_MST_GRL_PROYECTOS project = projects.FirstOrDefault();

            if (project == null)
            {
                return NotFound();
            }

            var typecontact = await _tipocontacto.GetAll();
            var contacts = await _contactos.GetAll(project.cliente_id);

            ViewBag.typecontactList = typecontact;
            ViewBag.contactList = contacts;

            return View(project);
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] SOLDOZA_MST_GRL_PROYECTOS project)
        {
            if (project == null)
            {
                return View("Customers");
            }


            SOLDOZA_MST_GRL_PROYECTOS proj = new SOLDOZA_MST_GRL_PROYECTOS()
            {
                cod_proyecto = project.cod_proyecto,
                descripcion_proyecto = project.descripcion_proyecto,
                cliente_id = project.cliente_id,
                usuario_creacion = "admin"
            };


            bool result = _proyectos.Insert(proj);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added customer" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddVersion([FromBody] SOLDOZA_MST_GRL_PROYECTOVERSION version)
        {
            if (version == null)
            {
                return View("Customers");
            }



            bool result = _proyectos.InsertVersion(version);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added version" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] SOLDOZA_MST_GRL_CONTACTOS contact)
        {
            if (contact == null)
            {
                return View("Customers");
            }


            SOLDOZA_MST_GRL_CONTACTOS cont = new SOLDOZA_MST_GRL_CONTACTOS()
            {
                cliente_id = contact.cliente_id,
                cod_contacto = contact.cod_contacto,
                nombre_contacto = contact.nombre_contacto,
                apellidos_contacto = contact.apellidos_contacto,
                email_contacto = contact.email_contacto,
                telefono_contacto = contact.telefono_contacto,
                estado = 'N'
            };


            bool result = _contactos.Insert(cont);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added contact" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditContact([FromBody] SOLDOZA_MST_GRL_CONTACTOS contact)
        {
            if (contact == null)
            {
                return View("Customers");
            }


            SOLDOZA_MST_GRL_CONTACTOS cont = new SOLDOZA_MST_GRL_CONTACTOS()
            {
                id = contact.id,
                cod_contacto = contact.cod_contacto,
                nombre_contacto = contact.nombre_contacto,
                apellidos_contacto = contact.apellidos_contacto,
                email_contacto = contact.email_contacto,
                telefono_contacto = contact.telefono_contacto,
                estado = 'N'
            };


            bool result = _contactos.Update(cont);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit contact" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }
        
        [HttpPost]
        public IActionResult AddContactProject([FromBody] SOLDOZA_MST_CONTACTOS_PROYECTO contact)
        {
            if (contact == null)
            {
                return View("Customers");
            }


            SOLDOZA_MST_CONTACTOS_PROYECTO cont = new SOLDOZA_MST_CONTACTOS_PROYECTO()
            {
                contacto_id = contact.contacto_id,
                proyecto_id = contact.proyecto_id,
                tipo_contacto_id = contact.tipo_contacto_id
            };


            bool result = _contactosproyecto.Insert(cont);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added contact" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }
        
        [HttpPost]
        public IActionResult DeleteContactProject([FromBody] SOLDOZA_MST_CONTACTOS_PROYECTO contact)
        {
            if (contact == null)
            {
                return View("Customers");
            }

            SOLDOZA_MST_CONTACTOS_PROYECTO cont = new SOLDOZA_MST_CONTACTOS_PROYECTO()
            {
                contacto_id = contact.contacto_id,
                proyecto_id = contact.proyecto_id,
                tipo_contacto_id = contact.tipo_contacto_id
            };


            bool result = _contactosproyecto.Delete(cont);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully delete contact" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }


        [HttpPost]
        public IActionResult AddMaterial([FromBody] SOLDOZA_MST_MATERIALES material)
        {
            if (material == null)
            {
                return View("Materials");
            }



            bool result = _materiales.Insert(material);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added material" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditMaterial([FromBody] SOLDOZA_MST_MATERIALES material)
        {
            if (material == null)
            {
                return View("Materials");
            }



            bool result = _materiales.Update(material);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit material" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddZone([FromBody] SOLDOZA_MST_ZONAS zone)
        {
            if (zone == null)
            {
                return View("Zones");
            }



            bool result = _zonas.Insert(zone);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added zone" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditZone([FromBody] SOLDOZA_MST_ZONAS zone)
        {
            if (zone == null)
            {
                return View("Zones");
            }



            bool result = _zonas.Update(zone);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit zone" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddSide([FromBody] SOLDOZA_ADM_MST_LADOS side)
        {
            if (side == null)
            {
                return View("Sides");
            }



            bool result = _lados.Insert(side);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added side" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditSide([FromBody] SOLDOZA_ADM_MST_LADOS side)
        {
            if (side == null)
            {
                return View("Sides");
            }



            bool result = _lados.Update(side);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit side" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddREND([FromBody] SOLDOZA_MST_RESULT_END rend)
        {
            if (rend == null)
            {
                return View("RENDS");
            }



            bool result = _rends.Insert(rend);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added result" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditREND([FromBody] SOLDOZA_MST_RESULT_END rend)
        {
            if (rend == null)
            {
                return View("RENDS");
            }



            bool result = _rends.Update(rend);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit result" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddPOSSOL([FromBody] SOLDOZA_MST_POS_SOLDEO posol)
        {
            if (posol == null)
            {
                return View("POSSOL");
            }



            bool result = _posol.Insert(posol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added welding position" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditPOSSOL([FromBody] SOLDOZA_MST_POS_SOLDEO posol)
        {
            if (posol == null)
            {
                return View("POSSOL");
            }



            bool result = _posol.Update(posol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit welding position" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }
    }
}
