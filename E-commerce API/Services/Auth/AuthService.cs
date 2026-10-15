using E_commerce_API.Data;
using E_commerce_API.DTOs.Auth;
using E_commerce_API.Models;
using E_commerce_API.Services.Audit;
using E_commerce_API.Services.TokenService;
using E_commerce_API.Exception;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Models.User?> Register(RegisterDTO register)
        {
            var exists = await _context.Users.AnyAsync(x => x.Email == register.Email);

            if (exists)
            {
                throw new BadRequestException("Email already exists.");
            }

            if (register.Password != register.ConfirmPassword)
            {
                throw new BadRequestException("Passwords do not match.");
            }

            var user = new Models.User
            {
                Email = register.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(register.Password),
                UserName = register.FullName,
                Phone = register.Phone,
                Role = enRole.Customer,
                IsActive = true,
                ShoppingCart = new Models.ShoppingCart()
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<Models.User?> Login(LoginDto dto)
        {
            var user = await _context.Users
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync(x => x.Email == dto.Email);
            
            if (user == null)
            {
                return null;
            }

            var passwordMatch = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!passwordMatch)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> Logout(RefreshDto dto)
        {
            var userId = _current.UserId;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email && x.Id == userId);

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

            // Prevent inactive users from getting new tokens
            if (!user.IsActive)
            {
                return null;
            }

            if (user.RefreshTokenExpiresAt < DateTime.UtcNow)
            {
                return null;
            }

            if (user.RefreshTokenRevokedAt != null)
            {
                return null;
            }

            return user;
        }
    }
}
