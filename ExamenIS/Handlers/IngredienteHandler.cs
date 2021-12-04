using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenIS.Models;
using System.Data;
using System.Data.SqlClient;

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

        public override ProductoModel ObtenerProducto(String idIngrediente) {
            String consulta = "SELECT * FROM Ingrediente WHERE idIngredientePK = @idIngrediente";
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, ConexionPizzeria);
            comandoParaConsulta.Parameters.AddWithValue("@idIngrediente", idIngrediente);
            return TransformarTablaALista(CrearTablaConsulta(comandoParaConsulta))[0];
        }
    }
}