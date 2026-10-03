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

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("AuthPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;
        public AuthController(AppDbContext context , IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }



        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromQuery] RegisterDTO register)
        {
            var chick = await _context.Users.AnyAsync(x=> x.Email==register.Email);

            if (chick)
            {
                return BadRequest("Email already exists.");
            }

            if (register.Password != register.confirmPassword)
            {
                return BadRequest("Password is Wronge");
            }


            var user = new User
            {
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
                UserName = register.FullName,
                Phone = register.phone,
                Role = enRole.Coustomer,
                IsActive = true,
                ShoppingCart = new ShoppingCart()

            };


            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var AccessToken = _jwtService.GenrateToken(user);
            var refreshtoken = await _jwtService.GenerateRefreshToken(user);

            return Ok(new
            {
                AccessToken = AccessToken,
                RefreshToken = refreshtoken,
            });
        }




        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromQuery] LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            var pass= BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!pass) 
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
        public async Task<IActionResult> Logout([FromQuery] RefreshDto dto)
        {
         
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);


            if (user == null)
            {

                return Unauthorized("Invalid refresh token.");
            }

            user.RefreshTokenRevokedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();


            return Ok("Logged out successfully.");

        }






        //[HttpPost("Logt")]
        ////[Authorize]
        //public async Task<IActionResult> test( int id)
        //{

        //    var category = await _context.Categore
        //       //.Include(x => x.Products)
        //       .Select(x=> new {x.Name,x.Products,x.Id})
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return Ok(category);
        //}




    }
}
