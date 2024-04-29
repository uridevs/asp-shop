using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;
using UriShop.Models;

namespace UriShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Rol> Roles { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Pedido> Pedidos { get; set; } = null!;
        public DbSet<Direccion> Direcciones { get; set; } = null!;
        public DbSet<Detalle_Pedido> DetallePedidos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Pedidos)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p=>p.UsuarioID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Producto>()
            .HasMany(p => p.DetallesPedido)
            .WithOne(dp => dp.Producto)
            .HasForeignKey(dp=>dp.ProductoID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
            .HasMany(p => p.DetallesPedido)
            .WithOne(dp => dp.Pedido)
            .HasForeignKey(dp=>dp.PedidoID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
            .Ignore(p=>p.Direccion);

            modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Productos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p=>p.CategoriaID)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}