using Microsoft.AspNetCore.Mvc;
using BakeryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AplicacionDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(AplicacionDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.ProductoId == id);

            if (producto == null) return NotFound();

            return View(producto);
        }
    }
}
