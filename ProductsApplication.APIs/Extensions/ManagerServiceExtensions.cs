using ProductsApplication.BL;

namespace ProductsApplication.APIs
{
    public static class ManagerServiceExtensions
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IProductManager, ProductManager>();
            return services;
        }
    }
}
