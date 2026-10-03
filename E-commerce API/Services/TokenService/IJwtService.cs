using E_commerce_API.Models;

namespace E_commerce_API.Services.TokenService
{
    public interface IJwtService
    {

        string GenrateToken(Models.User user);

        Task<string> GenerateRefreshToken(Models.User user);
        
    }
}
