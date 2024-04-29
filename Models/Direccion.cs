using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UriShop.Models
{
    public class Direccion
    {
        [Key]
        public int DireccionID { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; } = null!;
        [Required]
        [StringLength(25)]
        public string Ciudad { get; set; } = null!;
        [Required]
        [StringLength(25)]
        public string Provincia { get; set; } = null!;
        [Required]
        [StringLength(25)]
        public string Estado { get; set; } = null!;
        [Required]
        [StringLength(10)]
        public string CodigoPostal { get; set; } = null!;
        [Required]
        public int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; } = null!;
    }
}