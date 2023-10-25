using AutoMapper;
using ProductCatalog.DAL.Models;
using ProductCatalog.PL.ViewModels;

namespace ProductCatalog.PL.MappingProfiles
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductsViewModel, Products>().ReverseMap();
        }

    }
}
