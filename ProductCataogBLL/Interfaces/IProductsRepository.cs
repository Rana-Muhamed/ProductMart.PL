using ProductCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BLL.Interfaces
{
    public interface IProductsRepository:IGenericRepository<Products>
    {
        IQueryable<Products> SearchProductsByCategory(int catId);
        IQueryable<Products> CompareDuration(IEnumerable<Products> pr);

    }
}
