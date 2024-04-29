using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UriShop.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Modelo { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public decimal Precio { get; set; }
        [Required]
        [StringLength(255)]
        public string Imagen { get; set; } = null!;
        [Required]
        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public Categoria Categoria {get; set;} = null!;
        [Required]
        [StringLength(50)]
        public int Stock {get; set;}
        [Required]
        [StringLength(100)]
        public string Marca { get; set; } = null!;
        [Required]
        public bool Activo { get; set; }

        public ICollection<Detalle_Pedido> DetallesPedido {get; set;} = null!;

    }
}