using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UriShop.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        [Required]
        public int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; } = null!;
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Estado { get; set; } = null!;
        
        public int DireccionIdSeleccionada { get; set; }
        [ForeignKey("DireccionID")]
        public Direccion Direccion { get; set; } = null!;
        [Required]
        public decimal Total { get; set; }

        public ICollection<Detalle_Pedido> DetallesPedido {get; set;} = null!;

    }
}