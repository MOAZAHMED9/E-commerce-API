namespace E_commerce_API.Models
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal priceAtPurchase { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
