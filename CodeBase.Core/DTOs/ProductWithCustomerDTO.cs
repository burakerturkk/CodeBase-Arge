using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Core.DTOs
{
    public class ProductWithCustomerDTO : CustomerDTO
    {
        public ProductDTO Products { get; set; }
    }
}
