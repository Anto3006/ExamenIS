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

        public CarritoController() {
            AccesoMetodosProductosMenu = new ProductoMenuHandler();
        }

        public String AgregarProductoAlCarritoPorId(String idProducto, int cantidad) {
            if (Session["Carrito"] == null) {
                Session["Carrito"] = new CarritoModel();
            }
            return this.AgregarProductoAlCarrito(AccesoMetodosProductosMenu.ObtenerProducto(idProducto), cantidad);
        }
        public String AgregarProductoAlCarrito(ProductoModel producto, int cantidad) {
            CarritoModel carrito = Session["Carrito"] as CarritoModel;
            carrito.AgregarProductoAlCarrito(producto, cantidad);
            Session["Carrito"] = carrito;
            return "1";
        }
    }
}