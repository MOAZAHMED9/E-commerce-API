using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
