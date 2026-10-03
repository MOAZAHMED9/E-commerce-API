using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Review
{
    public class CreateReview
    {
        [Range(1, 10)]

        public int rate { get; set; }

        public string comment { get; set; }

        public int ProductId { get; set; }
        public int orderId { get; set; }
    }
}
