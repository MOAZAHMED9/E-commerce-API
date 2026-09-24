namespace E_commerce_API.Models
{
    public class CartItem : BaseEntity
    {
        public int quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
