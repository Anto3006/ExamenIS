async function agregarProductoAlCarrito(idProducto,cantidad) {
    await $.ajax({
        type: 'POST',
        url: $("#agregador-carrito").data("request-url"),
        data: { idProducto: idProducto, cantidad: cantidad },
        dataType: 'text',
        success: function (texto) {
        }
    });
}

async function agregarComboAlCarrito(idCombo, cantidad) {
    await $.ajax({
        type: 'POST',
        url: $("#agregador-carrito-combo").data("request-url"),
        data: { idCombo: idCombo, cantidad: cantidad },
        dataType: 'text',
        success: function (texto) {
        }
    });
}

async function cambiarCantidadCarrito(idProducto, nuevaCantidad) {
    await $.ajax({
        type: 'POST',
        url: $("#cambiar-cantidad-carrito").data("request-url"),
        data: { idProducto: idProducto, nuevaCantidad: nuevaCantidad },
        dataType: 'text',
        success: function (precioTotal) {
            document.getElementById("precio-total-compra").innerHTML = "₡" + precioTotal;
        }
    });
}

function actualizarCantidad(idProducto) {
    let seleccionadorCantidad = document.getElementById(idProducto).getElementsByClassName("seleccionador-cantidad")[0];
    cambiarCantidadCarrito(idProducto, parseInt(seleccionadorCantidad.value));
}

async function eliminarProductoCarrito(idProducto) {
    await $.ajax({
        type: 'POST',
        url: $("#eliminar-producto-carrito").data("request-url"),
        data: { idProducto: idProducto},
        success: function (precioTotal) {
            document.getElementById("precio-total-compra").innerHTML = "₡" + precioTotal;
        }
    });
}

function eliminarProducto(idProducto) {
    let filaProducto = document.getElementById(idProducto);
    eliminarProductoCarrito(idProducto)
    filaProducto.remove();
}