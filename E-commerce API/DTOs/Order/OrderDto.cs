using E_commerce_API.Models;

namespace E_commerce_API.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public decimal totalPrice { get; set; }
        public string Address { get; set; }
        public enStutes stutes { get; set; }
    }
}
