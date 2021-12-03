let ingredientesPosibles = new Map();
let ingredientesAgregados = [];
const PRECIO_BASE_PIZZA = 2000;
let precioTotal = PRECIO_BASE_PIZZA;


async function obtenerIngredientesPosibles() {
    await $.ajax({
        type: 'POST',
        url: $("#lista-ingredientes").data("request-url"),
        dataType: 'json',
        success: function (ingredientes) {
            ingredientes = JSON.parse(ingredientes)
            for (let ingrediente of ingredientes) {
                ingredientesPosibles[ingrediente["Id"]] = parseInt(ingrediente["Precio"]);
            }
        }
    });
}

function agregarIngrediente(nombreIngrediente, idIngrediente) {
    if (!ingredientesAgregados.includes(idIngrediente)) {
        ingredientesAgregados.push(idIngrediente);
        precioTotal += ingredientesPosibles[idIngrediente];
        let filaPrecioTotal = document.getElementById("fila-precio-total-pizza");
        filaPrecioTotal.parentElement.insertBefore(crearResumenIngrediente(nombreIngrediente, idIngrediente), filaPrecioTotal);
        let espacioPrecioTotal = document.getElementById("precio-total-pizza");
        espacioPrecioTotal.innerHTML = "₡" + precioTotal;
    }
}

function crearResumenIngrediente(nombreIngrediente, idIngrediente) {
    let filaIngrediente = document.createElement("div");
    filaIngrediente.classList.add(...["row","mb-3"]);
    let columnaNombre = document.createElement("div")
    columnaNombre.classList.add("col-3")
    columnaNombre.innerHTML = nombreIngrediente;
    let columnaPrecio = document.createElement("div")
    columnaPrecio.classList.add("col-3")
    columnaPrecio.innerHTML = "₡" + ingredientesPosibles[idIngrediente];
    let columnaBoton = document.createElement("div");
    columnaBoton.classList.add("col-1");
    let botonEliminar = document.createElement("button");
    botonEliminar.type = "button";
    botonEliminar.classList.add("btn-close", "btn-sm");
    columnaBoton.appendChild(botonEliminar);
    columnaBoton.addEventListener("click", () => { eliminarIngrediente(idIngrediente,filaIngrediente); })


    filaIngrediente.appendChild(columnaNombre);
    filaIngrediente.appendChild(columnaPrecio);
    filaIngrediente.appendChild(columnaBoton);

    return filaIngrediente;
}

function eliminarIngrediente(idIngrediente ,filaIngrediente) {
    ingredientesAgregados.splice(ingredientesAgregados.indexOf(idIngrediente), 1);
    precioTotal -= ingredientesPosibles[idIngrediente];
    let espacioPrecioTotal = document.getElementById("precio-total-pizza");
    espacioPrecioTotal.innerHTML = "₡" + precioTotal;
    filaIngrediente.remove();
}

async function agregarPizzaAlCarrito() {
    await $.ajax({
        type: 'POST',
        url: $("#agregador-carrito").data("request-url"),
        data: { idIngredientes: ingredientesAgregados },
        dataType: 'text',
        success: function (texto) {
            console.log(texto)
            console.log("Producto Agregado")
        }
    });
}