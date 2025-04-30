using BakeryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakeryWeb.Controllers
{
    public class CarritoController : Controller
    {
        private readonly AplicacionDbContext _context;
        public CarritoController(AplicacionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var carritoItems = _context.CarritoItem.Include(x => x.Producto).ToList();

            int totalProductos = carritoItems.Sum(item => item.Cantidad);

            ViewBag.TotalProductos = totalProductos;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarCarritoAjax(int productoId, int cantidad)
        {
            var producto = _context.Productos.Find(productoId);

            if (producto == null)
            {
                return Json(new { succes = false, message = "Producto no encontrado." });
            }

            var carritoItem = _context.CarritoItem.FirstOrDefault(x => x.ProductoId == productoId);
            if (carritoItem == null)
            {
                carritoItem = new CarritoItems
                {
                    ProductoId = productoId,
                    Cantidad = cantidad
                };
                _context.CarritoItem.Add(carritoItem);
            }
            else
            {
                carritoItem.Cantidad += cantidad;
            }

            _context.SaveChanges();
            int totalProductos = _context.CarritoItem.Sum(item => item.Cantidad);

            return Json(new { succes = true, message = "Producto agregado al carrito.", totalProductos });
        }
        [HttpPost]
        
        public IActionResult EliminarCarritoAjax(int carritoItemId)
        {
            var carritoItem = _context.CarritoItem.Find(carritoItemId);
            if (carritoItem == null)
            {
                return Json(new { succes = false, message = "Carrito item no encontrado." });
            }
            _context.CarritoItem.Remove(carritoItem);
            _context.SaveChanges();
            int totalProductos = _context.CarritoItem.Sum(item => item.Cantidad);
            return Json(new { succes = true, message = "Producto eliminado del carrito.", totalProductos });
        }
    }
}
