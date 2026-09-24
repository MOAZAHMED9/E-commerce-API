using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.Models
{
    public enum enRole {Coustomer=1, Admin }
    public class User : BaseEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string UserName { get; set; }


        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public  enRole Role { get; set; } 

        public bool IsActive { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
