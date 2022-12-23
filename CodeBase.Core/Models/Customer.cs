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
        public int ProductQuantity { get; set; }
        public Product Products { get; set; }
        public int ProductId { get; set; }
        //public DateTime ddd { get; set; }


    }
}
