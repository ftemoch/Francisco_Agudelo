﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parcial2V1.Services;
using Parcial2V1.Models;

namespace Parcial2V1.Controllers
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

            var clientesService = new ClientesServices();
            var model = clientesService.ListaClientes();

            return View(model);


        }
    }
}