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
        private readonly ILogger<ManagementController> _logger;
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
        private readonly ISOLDOZA_MST_LUGAR_SOLDEO _lugsol;
        private readonly ISOLDOZA_MST_END _ennode;
        private readonly ISOLDOZA_MST_DIS_SOLDADURA _dissol;
        private readonly ISOLDOZA_MST_PROC_SOLDADURA _procsol;
        private readonly ISOLDOZA_MST_TIPO_JUNTA _tipjun;
        private readonly ISOLDOZA_MST_SUBZONAS _subzona;
        private readonly ISOLDOZA_ADM_MST_CONSU_MARCA _consumar;
        private readonly ISOLDOZA_ADM_MST_CONSU_FABRICANTE _consufab;
        private readonly ISOLDOZA_ADM_MST_CONSU_CLASF_AWS _consuclasfaws;
        private readonly ISOLDOZA_MST_CONSUMIBLES _consumible;

        public ManagementController(ILogger<ManagementController> logger, ApplicationDbContext context,
                                    ISOLDOZA_MST_GRL_CLIENTES clientes, ISOLDOZA_MST_PAIS paises, ISOLDOZA_MST_TIPO_DOCUMENTO tipodocumentos,
                                    ISOLDOZA_MST_GRL_PROYECTOS proyectos, ISOLDOZA_MST_GRL_CONTACTOS contactos, ISOLDOZA_MST_TIPO_CONTACTO tipocontacto,
                                    ISOLDOZA_MST_CONTACTOS_PROYECTO contactosproyecto, ISOLDOZA_MST_MATERIALES materiales, ISOLDOZA_MST_ZONAS zonas, 
                                    ISOLDOZA_ADM_MST_LADOS lados, ISOLDOZA_MST_RESULT_END rends, ISOLDOZA_MST_POS_SOLDEO posol, ISOLDOZA_MST_LUGAR_SOLDEO lugsol,
                                    ISOLDOZA_MST_END ennode, ISOLDOZA_MST_DIS_SOLDADURA dissol, ISOLDOZA_MST_PROC_SOLDADURA procsol, ISOLDOZA_MST_TIPO_JUNTA tipjun,
                                    ISOLDOZA_MST_SUBZONAS subzona, ISOLDOZA_ADM_MST_CONSU_MARCA consumar, ISOLDOZA_ADM_MST_CONSU_FABRICANTE consufab,
                                    ISOLDOZA_ADM_MST_CONSU_CLASF_AWS consuclasfaws, ISOLDOZA_MST_CONSUMIBLES consumible)
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
            _lugsol = lugsol;
            _ennode = ennode;
            _dissol = dissol;
            _procsol = procsol;
            _tipjun = tipjun;
            _subzona = subzona;
            _consumar = consumar;
            _consufab = consufab;
            _consuclasfaws = consuclasfaws;
            _consumible = consumible;
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
        public IActionResult LugSol()
        {
            var lugsol = _lugsol .GetAll();
            return View(lugsol);
        }
        public IActionResult EnNoDe()
        {
            var ennode = _ennode.GetAll();
            return View(ennode);
        }
        public IActionResult DisSol()
        {
            var dissol = _dissol.GetAll();
            return View(dissol);
        }
        public IActionResult ProcSol()
        {
            var procsol = _procsol.GetAll();
            return View(procsol);
        }
        public IActionResult TipJun()
        {
            var tipjun = _tipjun.GetAll();
            return View(tipjun);
        }
        public async Task<IActionResult> SubZones()
        {
            var zonas = _zonas.GetAll();
            var subzona = await _subzona.GetAll();

            ViewBag.zonaslist = zonas;
            return View(subzona);
        }
        public IActionResult ConsuMar()
        {
            var consumar = _consumar.GetAll();
            return View(consumar);
        }
        public IActionResult ConsuFab()
        {
            var consufab = _consufab.GetAll();
            return View(consufab);
        }
        public IActionResult ConsuClasfaws()
        {
            var consuclasfaws = _consuclasfaws.GetAll();
            return View(consuclasfaws);
        }
        public IActionResult Consumible()
        {
            var consumible = _consumible.GetAll();
            return View(consumible);
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

        [HttpPost]
        public IActionResult AddLUGSOL([FromBody] SOLDOZA_MST_LUGAR_SOLDEO lugsol)
        {
            if (lugsol == null)
            {
                return View("POSSOL");
            }



            bool result = _lugsol.Insert(lugsol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added welding place" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditLUGSOL([FromBody] SOLDOZA_MST_LUGAR_SOLDEO lugsol)
        {
            if (lugsol == null)
            {
                return View("POSSOL");
            }



            bool result = _lugsol.Update(lugsol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit welding place" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddENNODE([FromBody] SOLDOZA_MST_END ennode)
        {
            if (ennode == null)
            {
                return View("ENNODE");
            }



            bool result = _ennode.Insert(ennode);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added non-destructive testing" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditENNODE([FromBody] SOLDOZA_MST_END ennode)
        {
            if (ennode == null)
            {
                return View("ENNODE");
            }



            bool result = _ennode.Update(ennode);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit non-destructive testing" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddDISSOL([FromBody] SOLDOZA_MST_DIS_SOLDADURA dissol)
        {
            if (dissol == null)
            {
                return View("DISSOL");
            }



            bool result = _dissol.Insert(dissol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added welding design" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditDISSOL([FromBody] SOLDOZA_MST_DIS_SOLDADURA dissol)
        {
            if (dissol == null)
            {
                return View("DISSOL");
            }



            bool result = _dissol.Update(dissol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit welding design" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddPROCSOL([FromBody] SOLDOZA_MST_PROC_SOLDADURA procsol)
        {
            if (procsol == null)
            {
                return View("PROCSOL");
            }



            bool result = _procsol.Insert(procsol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added welding process" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditPROCSOL([FromBody] SOLDOZA_MST_PROC_SOLDADURA procsol)
        {
            if (procsol == null)
            {
                return View("PROCSOL");
            }



            bool result = _procsol.Update(procsol);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit welding process" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddTIPJUN([FromBody] SOLDOZA_MST_TIPO_JUNTA tipjun)
        {
            if (tipjun == null)
            {
                return View("TIPJUN");
            }



            bool result = _tipjun.Insert(tipjun);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added joint type" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditTIPJUN([FromBody] SOLDOZA_MST_TIPO_JUNTA tipjun)
        {
            if (tipjun == null)
            {
                return View("TIPJUN");
            }



            bool result = _tipjun.Update(tipjun);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit joint type" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddSUBZONA([FromBody] SOLDOZA_MST_SUBZONAS subzona)
        {
            if (subzona == null)
            {
                return View("NPLAN");
            }

            bool result = _subzona.Insert(subzona);
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
        public IActionResult EditSUBZONA([FromBody] SOLDOZA_MST_SUBZONAS subzona)
        {
            if (subzona == null)
            {
                return View("NPLAN");
            }

            bool result = _subzona.Update(subzona);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit plan" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddCONSUMAR([FromBody] SOLDOZA_ADM_MST_CONSU_MARCA consumar)
        {
            if (consumar == null)
            {
                return View("CONSUMAR");
            }



            bool result = _consumar.Insert(consumar);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added brand" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditCONSUMAR([FromBody] SOLDOZA_ADM_MST_CONSU_MARCA consumar)
        {
            if (consumar == null)
            {
                return View("CONSUMAR");
            }



            bool result = _consumar.Update(consumar);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit brand" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddCONSUFAB([FromBody] SOLDOZA_ADM_MST_CONSU_FABRICANTE consufab)
        {
            if (consufab == null)
            {
                return View("CONSUFAB");
            }

            bool result = _consufab.Insert(consufab);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added manufacturer" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditCONSUFAB([FromBody] SOLDOZA_ADM_MST_CONSU_FABRICANTE consufab)
        {
            if (consufab == null)
            {
                return View("CONSUFAB");
            }

            bool result = _consufab.Update(consufab);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit manufacturer" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddCONSUCLASFAWS([FromBody] SOLDOZA_ADM_MST_CONSU_CLASF_AWS consuclasfaws)
        {
            if (consuclasfaws == null)
            {
                return View("CONSUCLASFAWS");
            }

            bool result = _consuclasfaws.Insert(consuclasfaws);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added AWS classification" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditCONSUCLASFAWS([FromBody] SOLDOZA_ADM_MST_CONSU_CLASF_AWS consuclasfaws)
        {
            if (consuclasfaws == null)
            {
                return View("CONSUCLASFAWS");
            }

            bool result = _consuclasfaws.Update(consuclasfaws);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit AWS classification" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult AddCONSUMIBLE([FromBody] SOLDOZA_MST_CONSUMIBLES consumible)
        {
            if (consumible == null)
            {
                return View("CONSUMIBLE");
            }

            bool result = _consumible.Insert(consumible);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully added consumible" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }

        [HttpPost]
        public IActionResult EditCONSUMIBLE([FromBody] SOLDOZA_MST_CONSUMIBLES consumible)
        {
            if (consumible == null)
            {
                return View("CONSUMIBLE");
            }

            bool result = _consumible.Update(consumible);
            if (result)
            {
                return Json(new { exito = true, mensaje = "Successfully edit consumible" });
            }
            else
            {
                return Json(new { exito = false, mensaje = "Error" });
            }
        }
    }
}
