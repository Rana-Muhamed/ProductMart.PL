using Microsoft.EntityFrameworkCore;
using ProductCatalog.BLL.Interfaces;
using ProductCatalog.PL.Contexts;
using ProductCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace ProductCatalog.BLL.Repositories
{
    public class ProductsRepository: GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(CatalogContext dbContext): base(dbContext)
        {

        }

        public IQueryable<Products> CompareDuration(IEnumerable<Products> Pr)

            => _dbContext.Products.Where(P => P.StartDate.Add(P.Duration) >= DateTime.Now && DateTime.Now >= P.StartDate);


        public IQueryable<Products> SearchProductsByCategory(int catId)


          //=> _dbcontext.P .Where(E => E.Name.ToLower().Contains(name.ToLower()));
          => _dbContext.Products.Where(P => P.CategoriesId== catId);

     
    }
}
