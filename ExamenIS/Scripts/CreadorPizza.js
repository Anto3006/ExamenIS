let ingredientesPosibles = new Map();
let ingredientesAgregados = [];
const PRECIO_BASE_PIZZA = 2000;
let precioTotal = PRECIO_BASE_PIZZA;


async function obtenerIngredientesPosibles(categoria, columnaOrdenamiento, direccionOrdenamiento) {
    await $.ajax({
        type: 'POST',
        url: $("#lista-ingredientes").data("request-url"),
        dataType: 'json',
        success: function (ingredientes) {
            ingredientes = JSON.parse(ingredientes)
            for (let ingrediente of ingredientes) {
                ingredientesPosibles[ingrediente["Nombre"]] = parseInt(ingrediente["Precio"]);
            }
        }
    });
}

function agregarIngrediente(nombreIngrediente) {
    if (!ingredientesAgregados.includes(nombreIngrediente)) {
        ingredientesAgregados.push(nombreIngrediente);
        precioTotal += ingredientesPosibles[nombreIngrediente];
        let filaPrecioTotal = document.getElementById("fila-precio-total-pizza");
        filaPrecioTotal.parentElement.insertBefore(crearResumenIngrediente(nombreIngrediente), filaPrecioTotal);
        let espacioPrecioTotal = document.getElementById("precio-total-pizza");
        espacioPrecioTotal.innerHTML = "₡" + precioTotal;
    }
}

function crearResumenIngrediente(nombreIngrediente) {
    let filaIngrediente = document.createElement("div");
    filaIngrediente.classList.add(...["row", "m-4"]);

    let columnaNombre = document.createElement("div")
    columnaNombre.classList.add("col-3")
    columnaNombre.innerHTML = nombreIngrediente;
    let columnaPrecio = document.createElement("div")
    columnaPrecio.classList.add("col-3")
    columnaPrecio.innerHTML = "₡" + ingredientesPosibles[nombreIngrediente];
    let columnaBoton = document.createElement("div");
    columnaBoton.classList.add("col-1");
    let botonEliminar = document.createElement("button");
    botonEliminar.type = "button";
    botonEliminar.classList.add("btn-close", "btn-sm");
    columnaBoton.appendChild(botonEliminar);
    columnaBoton.addEventListener("click", () => { eliminarIngrediente(nombreIngrediente, filaIngrediente); })


    filaIngrediente.appendChild(columnaNombre);
    filaIngrediente.appendChild(columnaPrecio);
    filaIngrediente.appendChild(columnaBoton);

    return filaIngrediente;
}

function eliminarIngrediente(nombreIngrediente, filaIngrediente) {
    ingredientesAgregados.splice(ingredientesAgregados.indexOf(nombreIngrediente), 1);
    precioTotal -= ingredientesPosibles[nombreIngrediente];
    let espacioPrecioTotal = document.getElementById("precio-total-pizza");
    espacioPrecioTotal.innerHTML = "₡" + precioTotal;
    filaIngrediente.remove();
}