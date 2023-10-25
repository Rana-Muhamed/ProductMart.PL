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
    public class CategoryRepository : GenericRepository<Categories>, ICategoryRepository

    {
        public CategoryRepository(CatalogContext dbContext) : base(dbContext)
        {

        }
    }
}
