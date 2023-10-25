using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BLL.Interfaces;
using ProductCatalog.DAL.Models;
using ProductCatalog.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.PL.Controllers
{
    public class UserProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            var dproducts = await _unitOfWork.ProductsRepository.GetAll();
            var duration = _unitOfWork.ProductsRepository.CompareDuration(dproducts);
            if(duration is not null) { 
            if (int.TryParse(SearchValue, out int searchIntValue))
            {
                var products = _unitOfWork.ProductsRepository.SearchProductsByCategory(searchIntValue);
                var mappedProduct = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductsViewModel>>(products);
                return View(mappedProduct);
            }
            else
            {
                var products = await _unitOfWork.ProductsRepository.GetAll();
                var mappedProduct = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductsViewModel>>(products);
                return View(mappedProduct);

            }
            }
            else { return View(null); }
        }
        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var product = await _unitOfWork.ProductsRepository.Get(id.Value);
            if (product == null)
                return NotFound();
            var mappedProduct = _mapper.Map<Products, ProductsViewModel>(product);

            return View(viewName, mappedProduct);
        }

    }
}