using CodeBase.Core.Models;
using CodeBase.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {

        }

        public Task<List<Customer>> GetProductWithCustomer()
        {
            return Task.FromResult(_context.Customers.Include(x => x.Products).ToList());
        }
    }
}
