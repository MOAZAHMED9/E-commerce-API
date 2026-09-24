using E_commerce_API.Data;
using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_commerce_API.Services.TokenService
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public JwtService(IConfiguration configuration , AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public string GenrateToken(User user )
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, (user.Role) == enRole.Coustomer? "Coustomer":"Admin")
            };


            var token = new JwtSecurityToken(
               issuer: jwtSettings["Issuer"],
               audience: jwtSettings["Audience"],
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes( Convert.ToDouble(jwtSettings["AccessTokenMinutes"])),            
               signingCredentials: credentials);                                  


            return new JwtSecurityTokenHandler()
                .WriteToken(token);

        }


        public async Task<string> GenerateRefreshToken(User user)
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            var refreshtocken = Convert.ToBase64String(bytes);

            user.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshtocken);      // بنخزن الهاش بتاع التوكن في الداتا بيز مش التوكن نفسه عشان الامان
            user.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            user.RefreshTokenRevokedAt = null;

            await _context.SaveChangesAsync();

            return refreshtocken;
        }

    }
}
