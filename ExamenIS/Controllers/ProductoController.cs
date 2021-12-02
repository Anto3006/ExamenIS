using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenIS.Handlers;
using ExamenIS.Models;

namespace ExamenIS.Controllers
{
    public class ProductoController : Controller
    {
        private IngredientesHandler AccesoMetodosIngredientes;

        public ProductoController() {
            AccesoMetodosIngredientes = new IngredientesHandler();
        }

        public ActionResult CrearPizzaPersonalizada() {
            ViewBag.Ingredientes = AccesoMetodosIngredientes.RecuperarListaIngredientes();
            return View();
        }
    }
}