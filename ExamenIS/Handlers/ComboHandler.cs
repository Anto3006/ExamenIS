using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenIS.Models;
using System.Data;
using System.Data.SqlClient;

namespace ExamenIS.Handlers
{
    public class ComboHandler : ProductoGeneralHandler
    {

        private ProductoMenuHandler AccesoMetodosProductoMenu;

        public ComboHandler() {
            AccesoMetodosProductoMenu = new ProductoMenuHandler();
        }
        protected override String ObtenerNombreTabla()
        {
            return "Combo";
        }

        protected override String AgregarVerificacionAdicional(String consulta)
        {
            return consulta + " WHERE esValido = 1";
        }

        protected override ProductoModel CrearProducto(DataRow producto)
        {
            CombosModel combo =  new CombosModel() {
                Id = producto["idComboPK"].ToString(),
                Nombre = producto["nombre"].ToString(),
                Precio = Convert.ToDouble(producto["precio"]),
                NombreImagen = producto["imagen"].ToString()
            };
            return RecuperarProductosCombo(combo);
        }

        public CombosModel RecuperarProductosCombo(CombosModel combo) {
            String consulta = "SELECT P.idProductoPK, P.nombre, P.precio, P.imagen FROM ComboTiene CT" +
                " JOIN Producto P ON P.idProductoPK = CT.idProductoFK" +
                " WHERE idComboFK = @idCombo";
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, ConexionPizzeria);
            comandoParaConsulta.Parameters.AddWithValue("@idCombo", combo.Id);
            DataTable tablaResultado = CrearTablaConsulta(comandoParaConsulta);
            combo.Productos = AccesoMetodosProductoMenu.TransformarTablaALista(tablaResultado);
            return combo;
        }
    }
}