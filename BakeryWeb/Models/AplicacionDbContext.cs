using Microsoft.EntityFrameworkCore;
using BakeryWeb.Models;

namespace BakeryWeb.Models
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<CarritoItems> CarritoItem { get; set; }

    }
}

