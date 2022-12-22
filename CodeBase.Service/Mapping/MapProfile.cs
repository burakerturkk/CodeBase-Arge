using AutoMapper;
using CodeBase.Core.DTOs;
using CodeBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Service.Mapping
{
    public class MapProfile : Profile
    {
       public MapProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderWithCustomerDTO>().ReverseMap();

        }
    }
}
