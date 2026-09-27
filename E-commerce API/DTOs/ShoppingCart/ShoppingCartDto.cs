namespace E_commerce_API.DTOs.ShoppingCart
{
    public class CartItemDto
    {
        public int productId {  get; set; }

        public string productName { get; set; }

        public int Quantity { get; set; }

    }

    public class ShoppingCartDto
    {
       
        public List<CartItemDto>? Items { get; set; }
    }
}
