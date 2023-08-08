using CatalogoProductos.Aplication.Interfaces;
using CatalogoProductos.Domain.Entities;

namespace CatalogoProductos.Aplication.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAllAsync(string name, string description, string category, string orderBy)
            => _productRepository.GetAllAsync(name, description, category, orderBy);

        public Task<Product> GetByIdAsync(int id)
            => _productRepository.GetByIdAsync(id);

        public Task CreateAsync(Product product)
            => _productRepository.CreateAsync(product);

        public Task UpdateAsync(Product product)
            => _productRepository.UpdateAsync(product);

        public Task DeleteAsync(int id)
            => _productRepository.DeleteAsync(id);
    }

}
