using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenIS.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ExamenIS.Handlers
{
    public class ProductoHandler
    {
        private String DIRECCION_ARCHIVO_INGREDIENTES = AppContext.BaseDirectory + "ingredientes/ingredientes.json";
        private String DIRECCION_ARCHIVO_PRODUCTOS_MENU = AppContext.BaseDirectory + "productos/productos.json";
        private String DIRECCION_ARCHIVO_PIZZAS_MENU = AppContext.BaseDirectory + "productos/pizzas.json";

        public List<ProductoModel> RecuperarListaIngredientes() {
            return RecuperarListaProductos(DIRECCION_ARCHIVO_INGREDIENTES);
        }

        public List<ProductoModel> RecuperarListaProductosMenu() {
            return RecuperarListaProductos(DIRECCION_ARCHIVO_PRODUCTOS_MENU);
        }

        public List<ProductoModel> RecuperarListaPizzasMenu(){
            return RecuperarListaProductos(DIRECCION_ARCHIVO_PIZZAS_MENU);
        }

        private List<ProductoModel> RecuperarListaProductos(String direccionArchivo) {
            List<ProductoModel> productos = new List<ProductoModel>();
            JToken productosJSON = JObject.Parse(System.IO.File.ReadAllText(direccionArchivo))["Productos"];
            foreach (JToken producto in (productosJSON as JArray))
            {
                    ProductoModel productoLeido = new ProductoModel() { 
                    Nombre = producto["Nombre"].ToString(),
                    Precio = Convert.ToDouble(producto["Precio"].ToString()),
                    NombreImagen = producto["Imagen"].ToString()
                };
                productos.Add(productoLeido);
            }
            return productos;
        }

        public String TransformarJsonListaProductos(List<ProductoModel> productos) {
            return JsonConvert.SerializeObject(productos);
        }
    }
}