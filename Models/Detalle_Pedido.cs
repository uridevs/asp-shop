using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UriShop.Models
{
    public class Detalle_Pedido
    {
        [Key]
        public int DetallePedidoId { get; set; }
        [Required]
        public int PedidoID { get; set; }
        [ForeignKey("PedidoID")]
        public Pedido Pedido { get; set; } = null!;
        [Required]
        public int ProductoID { get; set; }
        [ForeignKey("ProductoID")]
        public Producto Producto { get; set; } = null!;
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}