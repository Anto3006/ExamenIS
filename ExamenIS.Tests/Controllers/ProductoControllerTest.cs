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
    }
}
