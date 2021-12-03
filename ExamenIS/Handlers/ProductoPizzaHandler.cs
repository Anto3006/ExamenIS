using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Handlers
{
    public class ProductoPizzaHandler : ProductoMenuHandler
    {
        protected override String AgregarVerificacionAdicional(String consulta)
        {
            return consulta + " WHERE esPizza = 1";
        }
    }
}