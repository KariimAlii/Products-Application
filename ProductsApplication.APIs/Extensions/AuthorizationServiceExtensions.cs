using System.Security.Claims;

namespace ProductsApplication.APIs
{
    public static class AuthorizationServiceExtensions
    {
        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
        {
            // User , Manager , Administrator
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("ManagerOrAdministrator", policy => policy.RequireClaim(ClaimTypes.Role, "Manager", "Administrator"));
                    options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
                });
            return services;
        }
    }
}
