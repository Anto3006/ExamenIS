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

        public override IHtmlString GenerarDetalles()
        {
            String resumenDetalles = "<div class=\"row h4 mb-3 ms-3 me-3\" id=\"fila-precio-total\" style=\"font-size:small\">\n" +
                                        "<div class=\"col-5\">\n";
            foreach (ProductoModel ingrediente in Ingredientes)
            {
                if (ingrediente != Ingredientes[0])
                {
                    resumenDetalles += ", ";
                }
                resumenDetalles += ingrediente.Nombre;
            }
            resumenDetalles +=  "</div>\n" +
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