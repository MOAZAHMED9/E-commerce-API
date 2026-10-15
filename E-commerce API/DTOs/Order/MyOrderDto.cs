using E_commerce_API.Models;

namespace E_commerce_API.DTOs.Order
{
    public class MyOrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public OrderStatus stutes { get; set; }
    }
}
