using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductsApplication.BL;
using ProductsApplication.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsApplication.APIs
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;

        public TokenService(IConfiguration _configuration , UserManager<User> _userManager)
        {
            configuration = _configuration;
            userManager = _userManager;
        }
        public async Task<string> CreateToken(User user , DateTime expiryDate)
        {
            // generate and return JWT token
            // (secret key + claims) =====Hashing Algorithm====> token


            // Step1 : secret key + claims =====Hashing Algorithm====> Signing Credentials
            // using Microsoft.IdentityModel.Tokens package

            var userClaims = await userManager.GetClaimsAsync(user);

            var secretKey = configuration.GetValue<string>("SecretKey");
            var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(secretKeyInBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // Step2: Signing Credentials + Claims + expireDateTime ===> JWT
            // using Microsoft.IdentityModels.Token.JWT package
            var jwt = new JwtSecurityToken
                (
                    claims: userClaims,
                    notBefore: DateTime.Now,
                    expires: expiryDate,
                    signingCredentials: signingCredentials
                );

            // Step3: JWT =====Token Handler=====> string token
            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(jwt);
            return tokenString;
        }

    }
}
