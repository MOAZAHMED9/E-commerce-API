namespace E_commerce_API.Models
{
    public enum enStutes { Pending, Processing, Shipped, Delivered, Cancelled}
    public class Order : BaseEntity
    {
        public decimal totalPrice { get; set; }
        public  enStutes stutes { get; set; }

        public string shippingAddress { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
