using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context) {
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}