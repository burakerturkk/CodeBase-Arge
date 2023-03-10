using CodeBase.Core.DTOs;
using CodeBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<ProductWithCustomerDTO>> GetProductWithCustomer();

    }
}
