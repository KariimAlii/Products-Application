using ProductsApplication.BL;

namespace ProductsApplication.APIs
{
    public static class TokenServiceExtensions
    {
        public static IServiceCollection AddTokenServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
