using Microsoft.AspNetCore.Identity;
using ProductsApplication.DAL;

namespace ProductsApplication.APIs
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 5;

                    options.User.RequireUniqueEmail = true;

                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                })
                .AddEntityFrameworkStores<ProductsApplicationContext>();
            return services;
        }
    }

}
