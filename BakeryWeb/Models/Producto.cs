using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryWeb.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
        public bool EnStock { get; set; }

    }
}
