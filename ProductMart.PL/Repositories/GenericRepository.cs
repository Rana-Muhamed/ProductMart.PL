using Microsoft.EntityFrameworkCore;
using ProductCatalog.BLL.Interfaces;
using ProductCatalog.PL.Contexts;
using ProductCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private protected readonly CatalogContext _dbContext;
        public GenericRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(T item)
            =>await _dbContext.Set<T>().AddAsync(item);

        public void Delete(T item)
            => _dbContext.Set<T>().Remove(item);

        public async Task<T> Get(int id)
            => await _dbContext.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Products))
                return (IEnumerable<T>)await _dbContext.Products.Include(P => P.Categories).ToListAsync();
            else
                return await _dbContext.Set<T>().ToListAsync();
        }

        public void Update(T item)
             => _dbContext.Set<T>().Update(item);
    }
}
