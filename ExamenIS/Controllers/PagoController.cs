using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenIS.Models;

namespace ExamenIS.Controllers
{
    public class PagoController : Controller
    {

        public ActionResult PaginaDePago()
        {
            ViewBag.Carrito = Session["Carrito"];
            return View();
        }

        [HttpPost]
        public ActionResult PaginaDePago(String identificacionComprador)
        {
            ViewBag.Carrito = Session["Carrito"];
            ViewBag.NombreComprador = Request["nombre-comprador"];
            ViewBag.Identificacion = Request["identificacion-comprador"];
            ViewBag.Correo = Request["correo-comprador"];
            ViewBag.TipoEnvio = Request["opcionEnvio"];
            ViewBag.DetallesEnvio = Request["detalles-envio"];
            return View("PaginaConfirmacionCompra");
        }

        public ActionResult PaginaConfirmacionCompra() {
            Session["Carrito"] = new CarritoModel();
            return View();
        }
    }
}