using AutoMapper;
using CodeBase.Core.DTOs;
using CodeBase.Core.Models;
using CodeBase.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeBase_Arge.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var od = await _orderService.GetAllAsync();
            var odDto = _mapper.Map<List<OrderDTO>>(od.ToList());
            return View(odDto);


        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var order = await _orderService.GetAllAsync();
            var orderDto = _mapper.Map<List<OrderDTO>>(order.ToList());
            ViewBag.o = new SelectList(orderDto, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderDTO orderDTO)
        {
            Order o = new Order();
            if (ModelState.IsValid)
            {
                o.Id = orderDTO.Id;
                o.CustomerID = orderDTO.CustomerId;
                o.ProductID = orderDTO.ProductId;
                o.Quantity = orderDTO.Quantity;
                await _orderService.AddAsync(o);
                return RedirectToAction(nameof(Index));

            }
            var order = await _orderService.GetAllAsync();
            var orderDto = _mapper.Map<List<OrderDTO>>(order.ToList());
            ViewBag.o = new SelectList(orderDto, "Id", "Name");
            return View();
        }
    }
}
