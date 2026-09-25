using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
