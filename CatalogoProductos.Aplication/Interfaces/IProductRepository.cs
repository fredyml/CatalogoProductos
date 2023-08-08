using CatalogoProductos.Domain.Entities;

namespace CatalogoProductos.Aplication.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(string name, string description, string category, string orderBy);
        Task<Product> GetByIdAsync(int id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
