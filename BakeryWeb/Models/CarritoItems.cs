namespace BakeryWeb.Models
{
    public class CarritoItems
    {
        public int CarritoItemsId { get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
