using Microsoft.AspNetCore.Mvc;
using BakeryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AplicacionDbContext _context;
        public ProductoController(AplicacionDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();

            int totalProductos = _context.CarritoItem.Sum(item => item.Cantidad);
            return View(productos);
        }
    }
}
