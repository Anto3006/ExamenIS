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

        public virtual IHtmlString GenerarNombreResumen()
        {
            String resumenNombre =  "<div class=\"col-5\">\n" +
                                        Nombre + "\n" +
                                    "</div>\n";

            IHtmlString resumenNombreConvertido = new HtmlString(resumenNombre);
            return resumenNombreConvertido;
        }

        public virtual IHtmlString GenerarCantidadResumen(int cantidad)
        {
            String resumenCantidad =  "<div class=\"col-2\">" +
                                        "<input type = \"number\" class=\"form-control seleccionador-cantidad\" min=\"0\" style=\"width:60%\" onchange=\"actualizarCantidad('" + Id + "','" + Precio + "')\" value=\"" + cantidad.ToString() + "\">\n" +
                                    "</div>\n";

            IHtmlString resumenCantidadConvertido = new HtmlString(resumenCantidad);
            return resumenCantidadConvertido;
        }

        public virtual IHtmlString GenerarCantidadResumenPago(int cantidad)
        {
            String resumenCantidad = "<div class=\"col-2\">" +
                                        cantidad.ToString() +"\n"+
                                    "</div>\n";

            IHtmlString resumenCantidadConvertido = new HtmlString(resumenCantidad);
            return resumenCantidadConvertido;
        }

        public virtual IHtmlString GenerarBotonEliminarResumen()
        {
            String resumenPrecio =  "<div class=\"col-1\">" +
                                        "<button type = \"button\" class=\"btn-close btn-sm\" onclick=\"eliminarProducto('" + Id + "')\"></button>" +
                                    "</div>";

            IHtmlString resumenPrecioConvertido = new HtmlString(resumenPrecio);
            return resumenPrecioConvertido;
        }
        public virtual IHtmlString GenerarPrecioResumen(int cantidad)
        {
            String resumenPrecio = "<div class=\"col-3 precio-total-producto\">" +
                                        "₡" + (cantidad * Precio).ToString() + "\n" +
                                    "</div>";

            IHtmlString resumenPrecioConvertido = new HtmlString(resumenPrecio);
            return resumenPrecioConvertido;
        }

        public virtual IHtmlString GenerarDetalles() {
            String resumenDetalles = "";
            IHtmlString resumenDetallesConvertido = new HtmlString(resumenDetalles);
            return resumenDetallesConvertido;
        }

        public virtual String GenerarMargenes() {
            return "m-3";
        }
    }
}