using biblioteca.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace biblioteca.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // Modelos a mapear
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la relación entre Usuario y Rol
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol) // Un Usuario tiene un Rol
                .WithMany(r => r.Usuarios) // Un Rol tiene muchos Usuarios
                .HasForeignKey(u => u.FkRol) // La clave foránea es FkRol
                .OnDelete(DeleteBehavior.Restrict); // Evita la eliminación en cascada

            // Datos iniciales (seeding)
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "Admin"
                });

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Edgar",
                    UserName = "Usuario1",
                    Password = "123",
                    FkRol = 1
                });
        }
    }
}