using PCP.Data.Abstract;
using PCP.Data.Concrete.DbContexts;
using PCP.Data.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Data.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductCatalogDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        public UnitOfWork(ProductCatalogDbContext context)
        {
            _context = context;
        }
        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
