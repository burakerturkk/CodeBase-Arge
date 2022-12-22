using AutoMapper;
using CodeBase.Core.DTOs;
using CodeBase.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeBase_Arge.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cs = await _customerService.GetAllAsync();
            var csDto = _mapper.Map<List<CustomerDTO>>(cs.ToList());
            return View(csDto);
        }
    }
}
