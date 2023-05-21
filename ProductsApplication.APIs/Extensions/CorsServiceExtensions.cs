namespace ProductsApplication.APIs
{
    public static class CorsServiceExtensions
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection services, string PolicyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: PolicyName, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
