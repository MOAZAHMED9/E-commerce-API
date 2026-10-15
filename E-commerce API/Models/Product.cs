using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
