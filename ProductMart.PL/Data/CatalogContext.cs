using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.PL.Contexts
{
    public class CatalogContext: DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options):base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
