using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parcial2.Services;

namespace Parcial2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();


        }

        public ActionResult Cliente()
        {

            var clientesService = new ClientesService();
            var model = clientesService.ListaClientes();

            return View(model);


        }


    }
}