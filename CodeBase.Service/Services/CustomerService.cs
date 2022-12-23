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
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository = null, IMapper mapper = null) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductWithCustomerDTO>> GetProductWithCustomer()
        {
            var customers = await _customerRepository.GetProductWithCustomer();
            var customerDto = _mapper.Map<List<ProductWithCustomerDTO>>(customers);
            return customerDto;

        }
    }
}
