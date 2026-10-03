using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Review
{
    public class ReviewDto
    {
        
        public int rate { get; set; }

        public string comment { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }
    }
}
