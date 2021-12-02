using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class PizzaModel : ProductoModel
    {
        public List<IngredienteModel> Ingredientes { get; }
        private const double PRECIO_BASE_PIZZA = 2000;

        public void AgregarIngrediente(IngredienteModel ingredienteNuevo) {
            this.Ingredientes.Add(ingredienteNuevo);
        }

        public void CalcularPrecioAPartirIngredientes() {
            double precioNuevo = 0;
            foreach (IngredienteModel ingrediente in this.Ingredientes) {
                precioNuevo += ingrediente.Precio;
            }
            this.Precio = precioNuevo + PRECIO_BASE_PIZZA;
        }
    }
}