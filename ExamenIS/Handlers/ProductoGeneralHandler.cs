using System;
using System.Collections.Generic;
using ExamenIS.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ExamenIS.Handlers
{
    public class ProductoGeneralHandler
    {
        protected readonly SqlConnection ConexionPizzeria;

        public ProductoGeneralHandler() {
            String RutaConexionProducto = ConfigurationManager.ConnectionStrings["PizzeriaConnection"].ToString();
            ConexionPizzeria = new SqlConnection(RutaConexionProducto);
        }

        public List<ProductoModel> RecuperarListaProductos() {
            List<ProductoModel> productos = new List<ProductoModel>();
            String consulta = "SELECT * FROM " + ObtenerNombreTabla();
            consulta = AgregarVerificacionAdicional(consulta);
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, ConexionPizzeria);
            DataTable tablaProductos = CrearTablaConsulta(comandoParaConsulta);
            return TransformarTablaALista(tablaProductos);
        }

        protected virtual String ObtenerNombreTabla() {
            return "";
        }

        protected virtual String AgregarVerificacionAdicional(String consulta) {
            return consulta;
        }

        protected DataTable CrearTablaConsulta(SqlCommand comandoParaConsulta)
        {
            SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            SqlConnection conexionSQL = comandoParaConsulta.Connection;
            conexionSQL.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexionSQL.Close();
            return consultaFormatoTabla;
        }

        public List<ProductoModel> TransformarTablaALista(DataTable productos) {
            List<ProductoModel> productosLeidos = new List<ProductoModel>();
            foreach (DataRow producto in productos.Rows) {
                ProductoModel productoLeido = CrearProducto(producto);
                productosLeidos.Add(productoLeido);
            }
            return productosLeidos;
        }

        protected virtual ProductoModel CrearProducto(DataRow producto) {
            return new ProductoModel();
        }

        public String TransformarJsonListaProductos(List<ProductoModel> productos) {
            return JsonConvert.SerializeObject(productos);
        }

        public virtual ProductoModel ObtenerProducto(String idProducto) {
            return new ProductoModel();
        }
    }
}