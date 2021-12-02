using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenIS.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ExamenIS.Handlers
{
    public class IngredientesHandler
    {
        private String DIRECCION_ARCHIVO_INGREDIENTES = AppContext.BaseDirectory + "ingredientes/ingredientes.json";
        public List<IngredienteModel> RecuperarListaIngredientes() {
            List<IngredienteModel> ingredientes = new List<IngredienteModel>();
            JToken ingredientesJSON = JObject.Parse(System.IO.File.ReadAllText(DIRECCION_ARCHIVO_INGREDIENTES))["Ingredientes"];
            foreach (JToken ingrediente in (ingredientesJSON as JArray))
            {
                IngredienteModel ingredienteLeido = new IngredienteModel() { 
                    Nombre = ingrediente["Nombre"].ToString(),
                    Precio = Convert.ToDouble(ingrediente["Precio"].ToString()),
                    NombreImagen = ingrediente["Imagen"].ToString()
                };
                ingredientes.Add(ingredienteLeido);
            }
            return ingredientes;
        }

        public String TransformarJsonListaIngredientes(List<IngredienteModel> ingredientes) {
            return JsonConvert.SerializeObject(ingredientes);
        }
    }
}