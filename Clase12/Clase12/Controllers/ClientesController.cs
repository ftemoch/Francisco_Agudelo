using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clase12.Models;
using Clase12.ViewModels;

namespace Clase12.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _context;
        public ClientesController()
        {
            _context = new ApplicationDbContext();
        
        }

        



        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Crear vista para crear clientes
        public ActionResult Nueva()
        {
            var tipoClientes = _context.TipoClientes.ToList();
            var viewModel = new NewClienteViewModel
            {
                TipoClientes = tipoClientes
            };

            return View(viewModel);
        }

        //Metodo para encadenar la base de datos
        [HttpPost]

        public ActionResult Create(Cliente cliente)
        {
            if (cliente.ID == 0)
                _context.Clientes.Add(cliente);

            else
            {
                var clienteEnBd = _context.Clientes.Single(c => c.ID == cliente.ID);
                clienteEnBd.Nombre = cliente.Nombre;
                clienteEnBd.Apellido = cliente.Apellido;
                clienteEnBd.estaInscritoRevista = cliente.estaInscritoRevista;
                clienteEnBd.tipoCliente = cliente.tipoCliente;
            }
       

           // _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return RedirectToAction("Lista", "Clientes");
        }
          

     




        // GET: Clientes
        public ViewResult Lista()
        {
           // var clientes =GetClientes();
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        public ActionResult Details(int id)
        {
           // var cliente= GetClientes().SingleOrDefault(c=> c.ID==id);
            var cliente = _context.Clientes.SingleOrDefault(c => c.ID == id);
            if (cliente == null)

                return HttpNotFound();
            return View(cliente);
        }


        //Editar
        public ActionResult Edit(int id)
        {

            var cliente = _context.Clientes.SingleOrDefault(c => c.ID == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new NewClienteViewModel
            {
                Cliente = cliente,
                TipoClientes = _context.TipoClientes.ToList()
            };

            return View("Nueva", viewModel);
           
        }

        public ActionResult Eliminar(int id)
        {

            var cliente = _context.Clientes.SingleOrDefault(c => c.ID == id);
            if (cliente == null)
                return HttpNotFound();

            else
            {



                _context.Clientes.Remove(cliente);

                _context.SaveChanges();

               
            }
            return RedirectToAction("Lista", "Clientes");
        }

        private IEnumerable<Cliente> GetClientes()
        {
            return new List<Cliente>
            {
               // new Cliente {ID=1, Nombre="John Smith"},

                //new Cliente {ID=2, Nombre="Mary Williams"}
            };
        }
    }
}