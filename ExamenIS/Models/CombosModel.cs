using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class CombosModel : ProductoModel
    {
        public List<ProductoModel> Productos { get; set; }

        public override IHtmlString GenerarResumen(int cantidad)
        {
            String resumen = "<div id=\"" + Id + "\">" +
                                "<div class=\"row h4 mt-3 ms-3 me-3\">\n" +
                                     "<div class=\"col-5\">\n" +
                                        Nombre + "\n" +
                                     "</div>\n" +
                                     "<div class=\"col-2\">" +
                                        "<input type = \"number\" class=\"form-control seleccionador-cantidad\" min=\"0\" style=\"width:60%\" onchange=\"actualizarCantidad('" + Id + "')\" value=\"" + cantidad.ToString() + "\">\n" +
                                    "</div>\n" +
                                    "<div class=\"col-3\">" +
                                        "₡" + (cantidad * Precio).ToString() + "\n" +
                                    "</div>" +
                                    "<div class=\"col-1\">" +
                                        "<button type = \"button\" class=\"btn-close btn-sm\" onclick=\"eliminarProducto('" + Id + "')\"></button>" +
                                    "</div>\n" +
                                "</div>" +
                               "<div class=\"row h4 mb-3 ms-3 me-3\" style=\"font-size:small\">\n" +
                               "<div class=\"col-5\">\n";
            foreach (ProductoModel producto in Productos)
            {
                if (producto != Productos[0])
                {
                    resumen += ", ";
                }
                resumen += producto.Nombre;
            }
            resumen += "</div>\n" +
                        "</div>\n" +
                        "</div>\n";
            IHtmlString resumenConvertido = new HtmlString(resumen);
            return resumenConvertido;
        }
    }
}