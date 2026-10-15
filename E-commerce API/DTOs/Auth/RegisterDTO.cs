using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
