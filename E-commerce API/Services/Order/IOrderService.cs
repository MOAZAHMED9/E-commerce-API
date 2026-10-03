using E_commerce_API.DTOs.Order;

namespace E_commerce_API.Services.Order
{
    public interface IOrderService
    {
        Task <List<OrderDto>> GetAllOrders();
        Task <List<MyOrderDto>> GetMyOrders();
        Task <MyOrderDto> GetMyOrder(int Id);
        Task<List<OrderDetails>> OrderDetails();
        Task<bool> UpdateStatus(int OrderId);
        Task<bool> CancelOrder(int OrderId);

    }
}
