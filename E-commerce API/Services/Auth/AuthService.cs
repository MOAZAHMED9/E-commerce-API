using E_commerce_API.Data;
using E_commerce_API.DTOs.Auth;
using E_commerce_API.Models;
using E_commerce_API.Services.Audit;
using E_commerce_API.Services.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.SecurityTokenService;

namespace E_commerce_API.Services.Auth
{
    public class AuthService : IAuthService
    {

        private readonly AppDbContext _context;
        private readonly ICurrentUserService _current;
        public AuthService(AppDbContext context, ICurrentUserService current)
        {
            _context = context;
            _current = current;
        }



        public async Task <Models.User?> Register(RegisterDTO register)
        {
            var chick = await _context.Users
                .AnyAsync(x => x.Email == register.Email);

            if (chick)
            {
                throw new BadRequestException("Email already exists.");
            }

            if (register.Password != register.confirmPassword)
            {
                throw new BadRequestException("Password and confirm password do not match.");
            }

            var user = new Models.User
            {
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
                UserName = register.FullName,
                Phone = register.phone,
                Role = enRole.Coustomer,
                IsActive = true,
                ShoppingCart = new Models.ShoppingCart()
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }




        public async Task<Models.User?> Login( LoginDto dto)
        {
            var user = await _context.Users
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
            {
                return null;
            }

            var pass = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!pass)
            {
                return null;

            }

           
            return user;
        }


       
        public async Task<bool> Logout(RefreshDto dto)
        {
            var userid = _current.UserId;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email && x.Id == userid);


            if (user == null)
            {

                return false;
            }

            user.RefreshTokenRevokedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();


            return true;

        }

        public async Task<Models.User?> RefreshToken(RefreshDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
            {
                return null;
            }

            if(user.RefreshTokenExpiresAt< DateTime.UtcNow)
            {
                return null;
            }
            if(user.RefreshTokenRevokedAt != null)
            {
                
                return null;
            }
            return user;

        }
    }
}
