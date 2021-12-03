using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenIS.Models;
using ExamenIS.Handlers;

namespace ExamenIS.Controllers
{
    public class CarritoController : Controller
    {
        private ProductoMenuHandler AccesoMetodosProductosMenu;
        private ProductoPizzaPersonalizadaHandler AccesoMetodosPizzaPersonalizada;

        public CarritoController() {
            AccesoMetodosProductosMenu = new ProductoMenuHandler();
            AccesoMetodosPizzaPersonalizada = new ProductoPizzaPersonalizadaHandler();
        }

        public String AgregarProductoAlCarritoPorId(String idProducto, int cantidad) {
            if (Session["Carrito"] == null) {
                Session["Carrito"] = new CarritoModel();
            }
            return this.AgregarProductoAlCarrito(AccesoMetodosProductosMenu.ObtenerProducto(idProducto), cantidad);
        }
        public String AgregarProductoAlCarrito(ProductoModel producto, int cantidad) {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new CarritoModel();
            }
            CarritoModel carrito = Session["Carrito"] as CarritoModel;
            carrito.AgregarProductoAlCarrito(producto, cantidad);
            Session["Carrito"] = carrito;
            return "1";
        }

        public String AgregarPizzaPersonalizadaAlCarrito(List<String> idIngredientes) {
            int idPizza = (int)Session["IdPizzaPersonalizada"];
            ProductoModel pizzaPersonalizada = AccesoMetodosPizzaPersonalizada.CrearPizzaPersonalizada(idIngredientes,idPizza.ToString());
            idPizza += 1;
            Session["IdPizzaPersonalizada"] = idPizza;
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new CarritoModel();
            }
            CarritoModel carrito = Session["Carrito"] as CarritoModel;
            carrito.AgregarProductoAlCarrito(pizzaPersonalizada, 1);
            Session["Carrito"] = carrito;
            return "1";
        }

        public ActionResult CarritoDeCompras() {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new CarritoModel();
            }
            ViewBag.Carrito = Session["Carrito"];
            return View();
        }
    }
}