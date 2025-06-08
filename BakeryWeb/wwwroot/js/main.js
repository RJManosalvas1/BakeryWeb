document.addEventListener("DOMContentLoaded", function () {
    console.log("JS cargado correctamente");

    const botonesAgregar = document.querySelectorAll(".btn-agregar-carrito");

    botonesAgregar.forEach(btn => {
        btn.addEventListener("click", function () {
            const nombre = this.getAttribute("data-nombre");
            alert(`Producto "${nombre}" añadido al carrito`);
            // Aquí podrías hacer una llamada a API para agregar el producto
        });
    });
});
