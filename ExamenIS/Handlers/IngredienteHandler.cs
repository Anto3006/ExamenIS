using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenIS.Models;
using System.Data;

namespace ExamenIS.Handlers
{
    public class IngredienteHandler : ProductoGeneralHandler
    {
        protected override String ObtenerNombreTabla()
        {
            return "Ingrediente";
        }

        protected override ProductoModel CrearProducto(DataRow producto)
        {
            return new ProductoModel()
            {
                Id = producto["idIngredientePK"].ToString(),
                Nombre = producto["nombre"].ToString(),
                Precio = Convert.ToDouble(producto["precio"]),
                NombreImagen = producto["imagen"].ToString(),
            };
        }
    }
}