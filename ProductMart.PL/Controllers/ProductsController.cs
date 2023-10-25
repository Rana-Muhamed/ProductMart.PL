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
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if(int.TryParse(SearchValue, out int searchIntValue))
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
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Products products)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductsRepository.Add(products);
                await _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var product = await _unitOfWork.ProductsRepository.Get(id.Value);
            if (product == null)
                return NotFound();
            var mappedProduct = _mapper.Map<Products,ProductsViewModel>(product);

            return View(viewName, mappedProduct);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, ProductsViewModel ProductVM)

        {
            if (id != ProductVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedProduct = _mapper.Map<ProductsViewModel, Products>(ProductVM);
                    _unitOfWork.ProductsRepository.Update(mappedProduct);
                    await _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }

            return View(ProductVM);
        }
        public async Task<IActionResult> Delete(int? id)
        {

            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id, ProductsViewModel ProductsVM)
        {
            if (id != ProductsVM.Id)
                return BadRequest();
            try
            {
                var mappedProducts = _mapper.Map<ProductsViewModel, Products>(ProductsVM);
                _unitOfWork.ProductsRepository.Delete(mappedProducts);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                return View(ProductsVM);
            }
        }
    }
}
