using E_commerce_API.Models;

namespace E_commerce_API.DTOs.Order
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int userId { get; set; }
        public enStutes stutes { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public List<Review>? Reviews { get; set; }
    }


    public class  Review
    {
        public int rate { get; set; }

        public string? comment { get; set; }

    }
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }

}
