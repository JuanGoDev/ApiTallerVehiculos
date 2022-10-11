namespace TallerVehiculos.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TallerVehiculos.Entidades;
    using TallerVehiculos.Models;

    public class ApplicationDbContext: IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityModels>()
                .HasOne(bc => bc.TipoDocumento)
                .WithMany(b => b.IdentityModels)
                .HasForeignKey(bc => bc.IdTipoDocumento);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(bc => bc.IdentityModels)
                .WithMany(b => b.Vehiculos)
                .HasForeignKey(bc => bc.IdUsuario);
            modelBuilder.Entity<Vehiculo>()
                .HasOne(bc => bc.Marca)
                .WithMany(b => b.Vehiculos)
                .HasForeignKey(bc => bc.IdMarca);
            modelBuilder.Entity<Vehiculo>()
                .HasOne(bc => bc.TipoVehiculo)
                .WithMany(b => b.Vehiculos)
                .HasForeignKey(bc => bc.IdTipoVehiculo);

            modelBuilder.Entity<ImagenVehiculo>()
                .HasOne(bc => bc.Vehiculo)
                .WithMany(b => b.ImagenVehiculos)
                .HasForeignKey(bc => bc.Placa);

            modelBuilder.Entity<Historial>()
                .HasOne(bc => bc.Vehiculo)
                .WithMany(b => b.Historiales)
                .HasForeignKey(bc => bc.Placa)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Historial>()
                .HasOne(bc => bc.IdentityModels)
                .WithMany(b => b.Historiales)
                .HasForeignKey(bc => bc.IdUsuario);

            modelBuilder.Entity<DetalleHistorial>()
                .HasOne(bc => bc.Historial)
                .WithMany(b => b.DetalleHistoriales)
                .HasForeignKey(bc => bc.IdHistorial);
            modelBuilder.Entity<DetalleHistorial>()
                .HasOne(bc => bc.Procedimiento)
                .WithMany(b => b.DetalleHistoriales)
                .HasForeignKey(bc => bc.IdProcedimiento);
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<ImagenVehiculo> ImagenVehiculos { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<DetalleHistorial> DetalleHistoriales { get; set; }
        public DbSet<IdentityModels> User { get; set; }

    }
}
