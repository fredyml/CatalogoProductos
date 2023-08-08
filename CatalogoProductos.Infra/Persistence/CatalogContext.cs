using CatalogoProductos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Infra.Persistence
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<Product> Productos { get; set; }
    }
}
