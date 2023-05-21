using Microsoft.EntityFrameworkCore;
using ProductsApplication.DAL;

namespace ProductsApplication.APIs
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddDbContext<ProductsApplicationContext>(options =>
            {
                var LocalConnectionString = services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("LocalConnectionString");
                options.UseSqlServer(LocalConnectionString);
            });
            return services;
        }
    }
}
