using Microsoft.EntityFrameworkCore;
using ProductsApplication.DAL;

namespace ProductsApplication.APIs
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ConfigurationManager config)
        {
            //services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString()
            services.AddDbContext<ProductsApplicationContext>(options =>
            {
                string? LocalConnectionString = config.GetConnectionString("LocalConnectionString");
                options.UseSqlServer(LocalConnectionString);
            });
            return services;
        }
    }
}
