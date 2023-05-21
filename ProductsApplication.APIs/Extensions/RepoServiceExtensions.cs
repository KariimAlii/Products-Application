using ProductsApplication.DAL;
using System.Net.Sockets;

namespace ProductsApplication.APIs
{
    public static class RepoServiceExtensions
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepo, ProductRepo>();
            return services;
        }
    }
}
