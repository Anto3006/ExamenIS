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
    public class HomeControllerTest
    {
        [TestMethod]
        public void VerificarViewNotNull() {
            HomeController controlador = new HomeController();

            ViewResult vistaPaginaPrincipal = controlador.Index() as ViewResult;

            Assert.IsNotNull(vistaPaginaPrincipal);
        }

        [TestMethod]
        public void VerificarCantidadCombosPaginaPrincipal()
        {
            HomeController controlador = new HomeController();

            ViewResult vistaPaginaPrincipal = controlador.Index() as ViewResult;

            Assert.AreEqual(3, vistaPaginaPrincipal.ViewBag.Combos.Count);
        }
    }
}
