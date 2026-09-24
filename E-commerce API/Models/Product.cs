namespace E_commerce_API.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public bool IsAvailable { get; set; }
        
        public int CategoreId { get; set; }
        public Categore Categore { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
