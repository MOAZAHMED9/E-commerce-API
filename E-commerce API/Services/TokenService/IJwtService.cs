using E_commerce_API.Models;

namespace E_commerce_API.Services.TokenService
{
    public interface IJwtService
    {

        string GenrateToken(User user);

        Task<string> GenerateRefreshToken(User user);

    }
}
