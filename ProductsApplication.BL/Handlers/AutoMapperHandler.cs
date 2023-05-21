using AutoMapper;
using ProductsApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApplication.BL
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
               CreateMap<Product, ProductReadDto>();
               CreateMap<Product, ProductReadDto>();
               CreateMap<ProductAddDto, Product>();
               CreateMap<ProductUpdateDto, Product>();
        }
    }
}
