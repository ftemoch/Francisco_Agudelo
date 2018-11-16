using Clase12.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Clase12.Controllers
{
    public class TarifasController : Controller
    {
        private ApplicationDbContext _context;
        public TarifasController()
        {
            _context = new ApplicationDbContext();

        }





        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: Clientes
        public ViewResult ListaTarifas()
        {
            // var clientes =GetClientes();
            var Tarifas = _context.Tarifa.ToList();
            return View(Tarifas);
        }

        public ActionResult Details(int id)
        {
            // var cliente= GetClientes().SingleOrDefault(c=> c.ID==id);
            var tarifas = _context.Tarifa.SingleOrDefault(c => c.ID == id);
            if (tarifas == null)

                return HttpNotFound();
            return View(tarifas);
        }

        //Crear vista para crear clientes
         public ActionResult NuevaTarifa()
         {
             var tarifas = _context.Tarifa.ToList();
             var viewModel = new Tarifa
             {

             };

             return View(viewModel);
         }
         

        //Metodo para encadenar la base de datos
        [HttpPost]

        public ActionResult Create(Tarifa tarifa)
        {
            if (tarifa.ID == 0)
                _context.Tarifa.Add(tarifa);

            else
            {
                var tarifaEnBd = _context.Tarifa.Single(c => c.ID == tarifa.ID);
                tarifaEnBd.Nombre = tarifa.Nombre;
                tarifaEnBd.Monto = tarifa.Monto;
                tarifaEnBd.Descuento = tarifa.Descuento;
                tarifaEnBd.Fecha = tarifa.Fecha;


            }


            // _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return RedirectToAction("ListaTarifas", "Tarifas");
        }










        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = _context.Tarifa.Find(ID);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }
        [HttpPost]
        public ActionResult Edit(Tarifa tarifa)
        {
            _context.Entry(tarifa).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("ListaTarifas", "Tarifas");
        }


        public ActionResult Eliminar(int id)
        {

            var tarifas = _context.Tarifa.SingleOrDefault(c => c.ID == id);
            if (tarifas == null)
                return HttpNotFound();

            else
            {



                _context.Tarifa.Remove(tarifas);

                _context.SaveChanges();


            }
            return RedirectToAction("ListaTarifas", "Tarifas");
        }
        

        private IEnumerable<Tarifa> GetTarifa()
        {
            return new List<Tarifa>
            {
                // new Cliente {ID=1, Nombre="John Smith"},

                //new Cliente {ID=2, Nombre="Mary Williams"}
            };
        }
    }
}