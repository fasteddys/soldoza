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


        public ManagementController(ILogger<HomeController> logger, ApplicationDbContext context,
                                    ISOLDOZA_MST_GRL_CLIENTES clientes, ISOLDOZA_MST_PAIS paises, ISOLDOZA_MST_TIPO_DOCUMENTO tipodocumentos,
                                    ISOLDOZA_MST_GRL_PROYECTOS proyectos, ISOLDOZA_MST_GRL_CONTACTOS contactos, ISOLDOZA_MST_TIPO_CONTACTO tipocontacto,
                                    ISOLDOZA_MST_CONTACTOS_PROYECTO contactosproyecto)
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

    }
}
