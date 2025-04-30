using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BakeryWeb.Models;

namespace BakeryWeb.Data
{
    public class BakeryWebContext : DbContext
    {
        public BakeryWebContext (DbContextOptions<BakeryWebContext> options)
            : base(options)
        {
        }

        public DbSet<BakeryWeb.Models.Producto> Producto { get; set; } = default!;
        public DbSet<BakeryWeb.Models.CarritoItems> CarritoItems { get; set; } = default!;
    }
}
