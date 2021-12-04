using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace ExamenIS.Models
{
    public class CarritoModel
    {
        public List<ItemCarritoModel> Items { get; set; }
        public double PrecioTotal { get; set; }

        public CarritoModel()
        {
            Items = new List<ItemCarritoModel>();
            PrecioTotal = 0;
        }

        public void CalcularPrecioTotal()
        {
            PrecioTotal = 0;
            foreach (ItemCarritoModel itemCarrito in Items)
            {
                PrecioTotal += itemCarrito.PrecioTotal;
            }
        }

        public void AgregarProductoAlCarrito(ProductoModel producto, int cantidad)
        {
            if (VerificarSiProductoEnCarrito(producto))
            {
                AgregarCantidadAProducto(producto, cantidad);
            }
            else
            {
                Items.Add(new ItemCarritoModel(producto, cantidad));
            }
            CalcularPrecioTotal();
        }

        private bool VerificarSiProductoEnCarrito(ProductoModel producto)
        {
            foreach (ItemCarritoModel item in Items)
            {
                if (item.Producto.Equals(producto))
                {
                    return true;
                }
            }
            return false;
        }

        private void AgregarCantidadAProducto(ProductoModel producto, int cantidad)
        {
            foreach (ItemCarritoModel item in Items)
            {
                if (item.Producto.Equals(producto))
                {
                    item.Cantidad += cantidad;
                    item.CalcularPrecioTotal();
                }
            }
        }

        public void CambiarCantidadAProducto(String idProducto, int cantidad)
        {
            foreach (ItemCarritoModel item in Items)
            {
                if (item.Producto.Id == idProducto)
                {
                    item.Cantidad = cantidad;
                    item.CalcularPrecioTotal();
                }
            }
        }

        public void EliminarProductoCarrito(String idProducto) {
            ItemCarritoModel itemAEliminar = null;
            bool itemEncontrado = false;
            foreach (ItemCarritoModel item in Items)
            {
                if (item.Producto.Id == idProducto)
                {
                    itemEncontrado = true;
                    itemAEliminar = item;
                }
            }
            if (itemEncontrado) {
                Items.Remove(itemAEliminar);
            }
        }
    }
}