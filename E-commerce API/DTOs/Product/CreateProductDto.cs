using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal price { get; set; }
        [Required]
        [Range (0, int.MaxValue)]
        public int quantity { get; set; }
        [Required]
        public bool isActive { get; set; } = true;
        [Range (1, int.MaxValue)]
        public int CategoryId { get; set; }

    }
}
