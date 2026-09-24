namespace E_commerce_API.Models
{
    public class ShoppingCart : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
