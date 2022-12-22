using AutoMapper;
using CodeBase.Core.DTOs;
using CodeBase.Core.Models;
using CodeBase.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CodeBase_Arge.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
     
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
          
        }

        public async Task<IActionResult> Index()
        {
            var pr = await _productService.GetAllAsync();
            var prDto = _mapper.Map<List<ProductDTO>>(pr.ToList());
            return View(prDto);
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var product = await _productService.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDTO>>(product.ToList());
            ViewBag.pr = new SelectList(productDto, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            Product p = new Product();
            if (ModelState.IsValid)
            {
                p.Id = productDto.Id;
                p.Name = productDto.Name;
                p.Stock = productDto.Stock;
                p.Price = productDto.Price;
        
                //p.CustomerId = productDto.CustomerId;
                await _productService.AddAsync(p);
                return RedirectToAction(nameof(Index));
            }
            var product = await _productService.GetAllAsync();
            var productDTO = _mapper.Map<List<ProductDTO>>(product.ToList());
            ViewBag.pr = new SelectList(productDTO, "Id", "Name");
            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var products = await _productService.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDTO>>(products.ToList());
            ViewBag.pr = new SelectList(products, "Id", "Name", product.Id);
            return View(_mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                 await _productService.UpdateAsync(_mapper.Map<Product>(productDTO));
                return RedirectToAction(nameof(Index));

            }
            var product = await _productService.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDTO>>(product.ToList());
            ViewBag.pr = new SelectList(product, "Id", "Name", productDTO.Id);
            return View(productDTO);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
