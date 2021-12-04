using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenIS.Models
{
    public class ItemCarritoModel
    {
        public ProductoModel Producto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioTotal{ get; set; }

        public ItemCarritoModel(ProductoModel producto, int cantidad) {
            Producto = producto;
            Cantidad = cantidad;
            CalcularPrecioTotal();
        }

        public void AgregarCantidadProducto(int cantidadAdicional) {
            Cantidad += cantidadAdicional;
            CalcularPrecioTotal();
        }

        public void CalcularPrecioTotal() {
            PrecioTotal = Producto.Precio * Cantidad;
        }

    }
}