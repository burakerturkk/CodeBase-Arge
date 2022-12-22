using AutoMapper;
using CodeBase.Core.DTOs;
using CodeBase.Core.Models;
using CodeBase.Core.Repositories;
using CodeBase.Core.Services;
using CodeBase.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Service.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IGenericRepository<Order> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderWithCustomerDTO>> GetOrderWithCustomer()
        {
            var orders = await _orderRepository.GetOrderWithCustomer();
            var orderDto = _mapper.Map<List<OrderWithCustomerDTO>>(orders);
            return orderDto;

        }
    }
}
