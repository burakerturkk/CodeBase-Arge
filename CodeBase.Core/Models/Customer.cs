using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Core.Models
{
    public class Customer : BaseEntity
    {
   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
