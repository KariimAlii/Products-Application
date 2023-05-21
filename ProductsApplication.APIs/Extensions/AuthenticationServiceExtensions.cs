using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProductsApplication.APIs
{
    public static class AuthenticationServiceExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "jwtScheme";
                    options.DefaultChallengeScheme = "jwtScheme"; // User Not Authenticated ==> 401 UnAuthorized
                })
                .AddJwtBearer("jwtScheme", options =>
                {
                    var secretKey = services.BuildServiceProvider().GetService<IConfiguration>().GetValue<string>("SecretKey");
                    var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
                    var key = new SymmetricSecurityKey(secretKeyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });  
            return services;
        }
    }


}
