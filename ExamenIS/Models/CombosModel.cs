using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class CombosModel : ProductoModel
    {
        public List<ProductoModel> Productos { get; set; }

        public override IHtmlString GenerarDetalles()
        {
            String resumenDetalles = "<div class=\"row h4 mb-3 ms-3 me-3\" id=\"fila-precio-total\" style=\"font-size:small\">\n" +
                                        "<div class=\"col-5\">\n";
            foreach (ProductoModel producto in Productos)
            {
                if (producto != Productos[0])
                {
                    resumenDetalles += ", ";
                }
                resumenDetalles += producto.Nombre;
            }
            resumenDetalles += "</div>\n" +
                                "</div>\n";
            IHtmlString resumenDetallesConvertido = new HtmlString(resumenDetalles);
            return resumenDetallesConvertido;
        }

        public override String GenerarMargenes()
        {
            return "mt-3 ms-3 me-3";
        }
    }
}