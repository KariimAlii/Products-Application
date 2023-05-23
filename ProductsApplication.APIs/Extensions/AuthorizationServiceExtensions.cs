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
                    options.AddPolicy("Manager", policy => policy.RequireClaim(ClaimTypes.Role, "Manager"));
                    options.AddPolicy("Administrator", policy => policy.RequireClaim(ClaimTypes.Role, "Administrator"));
                    options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
                });
            return services;
        }
    }
}
