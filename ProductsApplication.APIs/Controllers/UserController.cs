using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductsApplication.BL;
using ProductsApplication.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ProductsApplication.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;

        public UserController(IConfiguration _configuration , UserManager<User> _userManager , ITokenService _tokenService)
        {
            configuration = _configuration;
            userManager = _userManager;
            tokenService = _tokenService;
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDTO>> Login (LoginDTO credentials)
        {
            var user = await userManager.FindByEmailAsync(credentials.Email);
            if (user is null)
            {
                return BadRequest(new CustomResponse(HttpStatusCode.BadRequest, "User Not Found"));
            }
            var isUserLocked = await userManager.IsLockedOutAsync(user);
            if (isUserLocked)
            {
                return BadRequest(new CustomResponse(HttpStatusCode.BadRequest, "Your Account is locked temporarily .. Please Try to login again later"));
            }
            var isAuthenticated = await userManager.CheckPasswordAsync(user,credentials.Password);
            if (!isAuthenticated)
            {
                await userManager.AccessFailedAsync(user);
                return Unauthorized(new CustomResponse(HttpStatusCode.Unauthorized, "Wrong Credentials! Try to login again.."));
            }
            var expiryDate = DateTime.Now.AddMinutes(15);
            var stringToken = await tokenService.CreateToken(user,expiryDate);
            var token = new TokenDTO
            {
                Token = stringToken,
                ExpiryDate = expiryDate
            };
            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO registerDTO)
        {
            // Mapping
            User newUser = new User
            {
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                UserName = registerDTO.FirstName + registerDTO.LastName
            };
            var creationResult = await userManager.CreateAsync(newUser, registerDTO.Password);
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newUser.UserName),
                new Claim(ClaimTypes.Email,newUser.Email),
                new Claim(ClaimTypes.Role,registerDTO.Title),
            };
            await userManager.AddClaimsAsync(newUser, userClaims);
            return Ok("New User Registered Successfully");
        }
    }
}
