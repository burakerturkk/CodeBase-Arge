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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Order>> GetOrderWithCustomer()
        {
            return Task.FromResult(_context.Orders.Include(x => x.Customers).ToList());
        }

     
    }
}
