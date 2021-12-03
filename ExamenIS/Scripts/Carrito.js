async function agregarProductoAlCarrito(idProducto,cantidad) {
    await $.ajax({
        type: 'POST',
        url: $("#agregador-carrito").data("request-url"),
        data: { idProducto: idProducto, cantidad: cantidad },
        dataType: 'text',
        success: function (texto) {
            console.log(texto)
            console.log("Producto Agregado")
        }
    });
}