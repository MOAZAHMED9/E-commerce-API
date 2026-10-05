using E_commerce_API.Data;
using E_commerce_API.DTOs.Auth;
using E_commerce_API.Models;
using E_commerce_API.Services.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_commerce_API.DTOs.Auth;
using Microsoft.AspNetCore.RateLimiting;
using E_commerce_API.Services.Audit;
using E_commerce_API.Services.Auth;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("AuthPolicy")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;


        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            var user = await _authService.Register(register);

            if (user == null)
            {
                return Conflict("Email already exists.");
            }

            var accessToken = _jwtService.GenrateToken(user);
            var refreshToken = await _jwtService.GenerateRefreshToken(user);

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _authService.Login(dto);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var AccessToken = _jwtService.GenrateToken(user);
            var refreshtoken = await _jwtService.GenerateRefreshToken(user);

            return Ok(new
            {
                AccessToken = AccessToken,
                RefreshToken = refreshtoken,
            });


        }



        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] RefreshDto dto)
        {
           var result = await _authService.Logout(dto);
            if (!result)
            {
                return BadRequest("Invalid refresh token.");
            }
            return Ok("Logged out successfully.");
        }

    }
}
