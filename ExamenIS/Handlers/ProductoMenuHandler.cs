using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenIS.Models;
using System.Data;

namespace ExamenIS.Handlers
{
    public class ProductoMenuHandler : ProductoGeneralHandler
    {
        protected override String ObtenerNombreTabla() {
            return "Producto";
        }

        protected override String AgregarVerificacionAdicional(String consulta)
        {
            return consulta + " WHERE esPizza = 0";
        }

        protected override ProductoModel CrearProducto(DataRow producto)
        {
            return new ProductoModel() {
                Id = producto["idProductoPK"].ToString(),
                Nombre = producto["nombre"].ToString(),
                Precio = Convert.ToDouble(producto["precio"]),
                NombreImagen = producto["imagen"].ToString(),
            };
        }
    }
}