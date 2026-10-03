using E_commerce_API.DTOs.ShoppingCart;
using E_commerce_API.Models;

namespace E_commerce_API.Services.ShoppingCart
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDto> GetMyCart();
        Task<bool> AddProduct(int id , int quantety);
        Task<bool>UpdateQuantity( int Productid ,int quantity);
        Task<bool> DeleteProduct(int ProductId);

        Task<bool> ClearCart();

        Task<Order> CheckoutAsync( string Address);
    }
}
