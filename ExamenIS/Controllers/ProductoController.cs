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
        private IngredienteHandler AccesoMetodosIngredientes;
        private ProductoMenuHandler AccesoMetodosProductosMenu;
        private ProductoPizzaHandler AccesoMetodosProductoPizza;
        private ComboHandler AccesoMetodosCombos;

        public ProductoController() {
            AccesoMetodosIngredientes = new IngredienteHandler();
            AccesoMetodosProductosMenu = new ProductoMenuHandler();
            AccesoMetodosProductoPizza = new ProductoPizzaHandler();
            AccesoMetodosCombos = new ComboHandler();
        }

        public ActionResult CrearPizzaPersonalizada() {
            ViewBag.Ingredientes = AccesoMetodosIngredientes.RecuperarListaProductos();
            return View();
        }

        public JsonResult ObtenerJsonIngredientes() {
            return Json(AccesoMetodosIngredientes.TransformarJsonListaProductos(AccesoMetodosIngredientes.RecuperarListaProductos()));
        }

        public ActionResult Menu() {
            ViewBag.ProductosMenu = AccesoMetodosProductosMenu.RecuperarListaProductos();
            ViewBag.PizzasMenu = AccesoMetodosProductoPizza.RecuperarListaProductos();
            ViewBag.Combos = AccesoMetodosCombos.RecuperarListaProductos();
            return View();
        }
    }
}