using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class ProductoModel
    {
        public String Nombre { get; set; }
        public double Precio { get; set; }
        public String NombreImagen { get; set; }

        public String Id { get; set; }

        public override bool Equals(object objeto)
        {
            if ((objeto == null) || !this.GetType().Equals(objeto.GetType()))
            {
                return false;
            }
            else
            {
                ProductoModel otroProducto = (ProductoModel)objeto;
                return otroProducto.Id == this.Id;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual IHtmlString GenerarResumen(int cantidad)
        {
            String resumen = "<div class=\"row h4 m-3\" id=\"" + Id + "\">\n" +
                             "<div class=\"col-5\">\n"+
                             Nombre + "\n" +
                             "</div>\n" +
                             "<div class=\"col-2\">"+
                             "<input type = \"number\" class=\"form-control seleccionador-cantidad\" min=\"0\" style=\"width:60%\" onchange=\"actualizarCantidad('" + Id + "')\" value=\"" + cantidad.ToString() + "\">\n"+
                            "</div>\n"+
                            "<div class=\"col-3\">"+
                                "₡" + (cantidad*Precio).ToString() + "\n" +
                            "</div>" +
                            "<div class=\"col-1\">" +
                                "<button type = \"button\" class=\"btn-close btn-sm\" onclick=\"eliminarProducto('" + Id + "')\"></button>" +
                            "</div>" + 
                           "</div>";
      
            IHtmlString resumenConvertido = new HtmlString(resumen);
            return resumenConvertido;
        }
    }
}