using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.Models
{
    public class Review : BaseEntity
    {
        [Range(1,10)]
        public int rate { get; set; }

        public string comment { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
    }
}
