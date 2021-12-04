using ExamenIS;
using ExamenIS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ExamenIS.Tests.Controllers
{
    [TestClass]
    public class ProductoControllerTest
    {
        [TestMethod]
        public void TestCantidadIngredientesPizzaPersonalizada() {
            ProductoController controladorProductos = new ProductoController();

            ViewResult vistaPizzaPersonalizada = controladorProductos.CrearPizzaPersonalizada() as ViewResult;

            Assert.AreEqual(6, vistaPizzaPersonalizada.ViewBag.Ingredientes.Count);
        }
        [TestMethod]
        public void TestCantidadProductosMenu() {
            ProductoController controladorProductos = new ProductoController();

            ViewResult vistaMenu = controladorProductos.Menu() as ViewResult;

            Assert.AreEqual(5, vistaMenu.ViewBag.ProductosMenu.Count);
        }
        [TestMethod]
        public void TestCantidadPizzasMenu()
        {
            ProductoController controladorProductos = new ProductoController();

            ViewResult vistaMenu = controladorProductos.Menu() as ViewResult;

            Assert.AreEqual(5, vistaMenu.ViewBag.PizzasMenu.Count);
        }
        [TestMethod]
        public void TestCantidadCombosMenu()
        {
            ProductoController controladorProductos = new ProductoController();

            ViewResult vistaMenu = controladorProductos.Menu() as ViewResult;

            Assert.AreEqual(3, vistaMenu.ViewBag.Combos.Count);
        }
    }
}
