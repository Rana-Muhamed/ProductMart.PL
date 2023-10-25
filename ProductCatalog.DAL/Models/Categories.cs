using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DAL.Models
{
    public class Categories
    {
        public int Id { get; set; } // Unique identifier for the category
        public string Name { get; set; } // Name of the category
        public ICollection<Products> Products { get; set; } = new HashSet<Products>();
    }
}
