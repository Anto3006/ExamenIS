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
        private ProductoHandler AccesoMetodosProductos;

        public ProductoController() {
            AccesoMetodosProductos = new ProductoHandler();
        }

        public ActionResult CrearPizzaPersonalizada() {
            ViewBag.Ingredientes = AccesoMetodosProductos.RecuperarListaIngredientes();
            return View();
        }

        public JsonResult ObtenerJsonIngredientes() {
            return Json(AccesoMetodosProductos.TransformarJsonListaProductos(AccesoMetodosProductos.RecuperarListaIngredientes()));
        }

        public ActionResult Menu() {
            ViewBag.ProductosMenu = AccesoMetodosProductos.RecuperarListaProductosMenu();
            ViewBag.PizzasMenu = AccesoMetodosProductos.RecuperarListaPizzasMenu();
            return View();
        }
    }
}