using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Review
{
    public class UpdateReviewDto
    {
        [Range(1, 10)]

        public int rate { get; set; }

        public string comment { get; set; }

    }
}
