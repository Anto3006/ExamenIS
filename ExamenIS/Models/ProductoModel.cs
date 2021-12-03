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
    }
}