using CodeBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<Customer>> GetProductWithCustomer();

    }
}
