using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenIS.Handlers;

namespace ExamenIS.Controllers
{
    public class HomeController : Controller
    {

        private ComboHandler AccesoMetodosCombo;
        public HomeController() {
            AccesoMetodosCombo = new ComboHandler();
        }
        public ActionResult Index()
        {
            ViewBag.Combos = AccesoMetodosCombo.RecuperarListaProductos();
            return View();
        }
    }
}