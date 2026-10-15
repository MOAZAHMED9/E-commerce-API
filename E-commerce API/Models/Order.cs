namespace E_commerce_API.Models
{
    public enum OrderStatus { Pending, Processing, Shipped, Delivered, Cancelled }
    
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
