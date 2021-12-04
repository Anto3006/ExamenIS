using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExamenIS.Controllers;
using Moq;
using System.Web.Mvc;
using ExamenIS.Models;
using System.Collections.Generic;

namespace ExamenIS.Tests.Controllers
{
    [TestClass]
    public class CarritoControllerTest
    {

        private CarritoController ObtenerCarritoController() {
            CarritoController controlador = new CarritoController();
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.Session["Carrito"]).Returns(new CarritoModel());
            controllerContext.SetupGet(p => p.HttpContext.Session["IdPizzaPersonalizada"]).Returns(0);
            controlador.ControllerContext = controllerContext.Object;
            return controlador;
        }
        [TestMethod]
        public void TestAgregarProductoMenuCarrito()
        {
            CarritoController controlador = ObtenerCarritoController();

            controlador.AgregarProductoAlCarritoPorId("P1", 1);
            CarritoModel carrito = (CarritoModel)controlador.Session["Carrito"];


            Assert.AreEqual(1, carrito.Items.Count);
        }

        [TestMethod]
        public void TestAgregarProductoMenuCarritoCorrecto()
        {
            CarritoController controlador = ObtenerCarritoController();

            String idProducto = "P1";
            controlador.AgregarProductoAlCarritoPorId(idProducto, 1);
            CarritoModel carrito = (CarritoModel)controlador.Session["Carrito"];


            Assert.AreEqual(idProducto, carrito.Items[0].Producto.Id);
        }
        [TestMethod]
        public void TestAgregarPizzaPersonalizadaCarrito() {
            CarritoController controlador = ObtenerCarritoController();

            List<String> ingredientesId = new List<String>();
            ingredientesId.Add("I1");
            ingredientesId.Add("I2");
            controlador.AgregarPizzaPersonalizadaAlCarrito(ingredientesId);
            CarritoModel carrito = (CarritoModel)controlador.Session["Carrito"];


            Assert.AreEqual(1, carrito.Items.Count);
        }
    }
}
