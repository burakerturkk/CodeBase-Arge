using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Core.Models
{
    public class Order : BaseEntity
    {
        public int Quantity { get; set; }
       public Customer Customers { get; set; }
        public Product Products { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
    }
}
