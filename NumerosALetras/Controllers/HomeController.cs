﻿using NumerosALetras.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumerosALetras.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string ConvertirNumerosALetras(string numero)
        {
            numero = ClsNumerosALetras.ConvertirNumerosALetras(numero);
            return numero;
        }
    }
}