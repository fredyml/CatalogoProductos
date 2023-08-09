using CatalogoProductos.Aplication.Dtos;
using CatalogoProductos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Infra.Persistence
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Context.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Product> Productos { get; set; }
    }
}
