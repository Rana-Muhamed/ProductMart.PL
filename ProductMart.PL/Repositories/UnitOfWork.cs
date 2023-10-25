using Microsoft.EntityFrameworkCore;
using ProductCatalog.BLL.Interfaces;
using ProductCatalog.PL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _dbContext;
        public IProductsRepository ProductsRepository { get ; set; }
        public ICategoryRepository CategoryRepository { get ; set; }
        public UnitOfWork(CatalogContext dbContext)
        {
            _dbContext = dbContext;
            ProductsRepository = new ProductsRepository(dbContext);
            CategoryRepository = new CategoryRepository(dbContext);
        }
    
        async Task<int> IUnitOfWork.Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
