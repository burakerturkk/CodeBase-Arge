using AutoMapper;
using CodeBase.Core.DTOs;
using CodeBase.Core.Models;
using CodeBase.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeBase_Arge.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper, IProductService productService = null)
        {
            _customerService = customerService;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _customerService.GetProductWithCustomer());
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var customer = await _productService.GetAllAsync();
            var customerDto = _mapper.Map<List<ProductDTO>>(customer.ToList());
            ViewBag.ct = new SelectList(customerDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDTO customerDTO)
        {
            Customer c = new Customer();

            if (ModelState.IsValid)
            {
                c.Id = customerDTO.Id;
                c.FirstName = customerDTO.FirstName;
                c.LastName = customerDTO.LastName;
                c.Mail = customerDTO.Mail;
                c.ProductQuantity = customerDTO.ProductQuantity;
                c.ProductId = customerDTO.ProductId;

                var prod = _productService.GetByIdAsync(customerDTO.ProductId).Result;
                if (customerDTO.ProductQuantity <= prod.Stock)
                {
                    await _customerService.AddAsync(c);
                    prod.Stock = prod.Stock - customerDTO.ProductQuantity;
                    await _productService.UpdateAsync(prod);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    WarningText(customerDTO.ProductQuantity, prod.Stock);
                    return View();
                }
            }
            else
            {
                WarningText();
                return View();
            }
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            var product = await _productService.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDTO>>(product.ToList());
            ViewBag.pr = new SelectList(productDto, "Id", "Name", customer.ProductId);
            return View(_mapper.Map<CustomerDTO>(customer));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(_mapper.Map<Customer>(customerDTO));
                return RedirectToAction(nameof(Index));
            }
            var product = await _productService.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDTO>>(product.ToList());
            ViewBag.pr = new SelectList(productDto, "Id", "Name", customerDTO.ProductId);
            return View(customerDTO);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            await _customerService.RemoveAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// ProductQueantity ve Stock bilgisi default olarak 0 sağlanmıştır. Bilgiye sahip değilseniz, boş gönderin.
        /// </summary>
        /// <param name="ProductQuantity"></param>
        /// <param name="Stock"></param>
        private void WarningText(int ProductQuantity = 0, int Stock = 0)
        {
            if (ProductQuantity != 0 || Stock != 0)
                ViewBag.StockCount = $"Bu Ürün {Stock} Adet İle Sınırlıdır. {ProductQuantity} Adet Satın Alamazsınız / Satamazsınız";

            var customer = _productService.GetAllAsync().Result;
            var customerDto = _mapper.Map<List<ProductDTO>>(customer.ToList());
            ViewBag.ct = new SelectList(customerDto, "Id", "Name");
        }

    }
}
