using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Auth
{
    public class RefreshDto
    {
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
