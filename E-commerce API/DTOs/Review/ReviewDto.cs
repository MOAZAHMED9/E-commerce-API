using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public int Rate { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
