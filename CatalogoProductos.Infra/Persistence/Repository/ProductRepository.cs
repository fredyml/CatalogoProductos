﻿using CatalogoProductos.Aplication.Enums;
using CatalogoProductos.Aplication.Interfaces;
using CatalogoProductos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Infra.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            _context.Productos.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product != null)
            {
                _context.Productos.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string name, string description, string category, OrderByOptions orderBy, bool isAscending)
        {
            var query = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (!string.IsNullOrEmpty(description))
                query = query.Where(p => p.Description.Contains(description));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

             switch (orderBy)
            {
                case OrderByOptions.Name:
                    query = isAscending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                    break;
                case OrderByOptions.Category:
                    query = isAscending ? query.OrderBy(p => p.Category) : query.OrderByDescending(p => p.Category);
                    break;
            }

            return await query.ToListAsync();
        }


        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.Id == product.Id))
                    throw new KeyNotFoundException("Product not found.");
                else
                    throw; 
            }
        }
    }
}
