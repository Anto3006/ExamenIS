using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class PizzaPersonalizadaModel : ProductoModel
    {
        public List<ProductoModel> Ingredientes { get; }
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
    }
}