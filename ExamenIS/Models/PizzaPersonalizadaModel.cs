using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class PizzaPersonalizadaModel : ProductoModel
    {
        public List<ProductoModel> Ingredientes { get; set; }
        private const double PRECIO_BASE_PIZZA = 2000;

        public void AgregarIngrediente(ProductoModel ingredienteNuevo) {
            this.Ingredientes.Add(ingredienteNuevo);
        }

        public void CalcularPrecioAPartirIngredientes() {
            double precioNuevo = 0;
            foreach (ProductoModel ingrediente in this.Ingredientes) {
                precioNuevo += ingrediente.Precio;
            }
            this.Precio = precioNuevo + PRECIO_BASE_PIZZA;
        }

        public override IHtmlString GenerarResumen(int cantidad)
        {
            String resumen = "<div id=\"" + Id + "\">" +
                                "<div class=\"row h4 mt-3 ms-3 me-3\" id=\"" + Id + "\">\n" +
                                     "<div class=\"col-5\">\n" +
                                     Nombre + "\n" +
                                     "</div>\n" +
                                     "<div class=\"col-2\">" +
                                     "<input type = \"number\" class=\"form-control seleccionador-cantidad\" min=\"0\" style=\"width:60%\" onchange=\"actualizarCantidad('" + Id + "','" + Precio + "')\" value=\"" + cantidad.ToString() + "\">\n" +
                                    "</div>\n" +
                                    "<div class=\"col-3 precio-total-producto\">" +
                                        "₡" + (cantidad * Precio).ToString() + "\n" +
                                    "</div>" +
                                    "<div class=\"col-1\">" +
                                        "<button type = \"button\" class=\"btn-close btn-sm\" onclick=\"eliminarProducto('" + Id + "')\"></button>" +
                                    "</div>\n" +
                                "</div>" +
                           "<div class=\"row h4 mb-3 ms-3 me-3\" id=\"fila-precio-total\" style=\"font-size:small\">\n" +
                           "<div class=\"col-5\">\n";
            foreach (ProductoModel ingrediente in Ingredientes) {
                if (ingrediente != Ingredientes[0]) {
                    resumen += ", ";
                }
                resumen += ingrediente.Nombre;
            }
            resumen +=  "</div>\n" +
                        "</div>\n" +
                        "</div>\n";
            IHtmlString resumenConvertido = new HtmlString(resumen);
            return resumenConvertido;
        }
    }
}