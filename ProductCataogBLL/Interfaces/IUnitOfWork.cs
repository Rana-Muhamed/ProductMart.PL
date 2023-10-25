using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BLL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IProductsRepository ProductsRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        Task<int> Complete();
    }
}
