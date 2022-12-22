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
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
