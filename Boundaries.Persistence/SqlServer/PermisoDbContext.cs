using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Boundaries.Persistence.SqlServer
{
    public sealed class PermisoDbContext : DbContext
    {
        public PermisoDbContext(DbContextOptions options) : base(options) { }

        internal DbSet<Permiso> Permisos { get; set; }
        internal DbSet<TipoPermiso> TipoPermisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoPermiso>().HasData(
                new TipoPermiso { Id = 1, Description = "Enfermedad" },
                new TipoPermiso { Id = 2, Description = "Diligencias" },
                new TipoPermiso { Id = 3, Description = "Universidad" },
                new TipoPermiso { Id = 4, Description = "Dentista" },
                new TipoPermiso { Id = 5, Description = "Almorzar" });
        }
    }
}
