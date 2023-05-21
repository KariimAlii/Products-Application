using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsApplication.BL;
using ProductsApplication.DAL;

namespace ProductsApplication.APIs
{
    public static class AutoMapperServiceExtensions
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }

}
