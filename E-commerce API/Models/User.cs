using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.Models
{
    public enum enRole { Customer = 1, Admin }
    
    public class User : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        public enRole Role { get; set; }

        public bool IsActive { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public string? RefreshTokenHash { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }
        public DateTime? RefreshTokenRevokedAt { get; set; }
    }
}
