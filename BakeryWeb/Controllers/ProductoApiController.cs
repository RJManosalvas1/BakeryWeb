using Microsoft.AspNetCore.Mvc;
using BakeryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoApiController : ControllerBase
    {
        private readonly AplicacionDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductoApiController(AplicacionDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/ProductoApi
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

        // GET: api/ProductoApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Producto producto, IFormFile imagen)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (imagen == null || imagen.Length == 0)
                return BadRequest(new { error = "Debe subir una imagen válida." });

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagen.FileName);
            var rutaGuardado = Path.Combine("wwwroot", "images", fileName);

            using (var stream = new FileStream(rutaGuardado, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            producto.ImagenUrl = "/images/" + fileName;

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = producto.ProductoId }, producto);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound(new { message = "Producto no encontrado" });

            if (!string.IsNullOrEmpty(producto.ImagenUrl))
            {
                var filePath = Path.Combine(_env.WebRootPath, producto.ImagenUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
