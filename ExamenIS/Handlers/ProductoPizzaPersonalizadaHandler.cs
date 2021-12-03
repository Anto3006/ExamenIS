using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenIS.Models;

namespace ExamenIS.Handlers
{
    public class ProductoPizzaPersonalizadaHandler : ProductoGeneralHandler
    {
        private IngredienteHandler AccesoMetodosIngredientes;

        public ProductoPizzaPersonalizadaHandler() {
            AccesoMetodosIngredientes = new IngredienteHandler();
        }

        public PizzaPersonalizadaModel CrearPizzaPersonalizada(List<String> idIngredientes, String idPizza) {
            PizzaPersonalizadaModel pizza = new PizzaPersonalizadaModel() {
                Nombre = "Pizza Personalizada",
                Id = idPizza,
                Ingredientes = new List<ProductoModel>()
            };
            foreach (String ingredienteId in idIngredientes) {
                ProductoModel ingrediente = AccesoMetodosIngredientes.ObtenerProducto(ingredienteId);
                pizza.Ingredientes.Add(ingrediente);
            }
            pizza.CalcularPrecioAPartirIngredientes();
            return pizza;
        }
    }
}