using E_commerce_API.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Services.Auth
{
    public interface IAuthService
    {
        Task<Models.User?> Register(RegisterDTO register);
        Task<Models.User?> Login(LoginDto dto);
        Task<bool> Logout(RefreshDto dto);
    }
}
