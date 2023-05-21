using ProductsApplication.DAL;

namespace ProductsApplication.BL
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user, DateTime expiryDate);
    }
}
