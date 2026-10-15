using E_commerce_API.Data;
using E_commerce_API.DTOs.Order;
using E_commerce_API.Models;
using E_commerce_API.Services.Audit;
using Microsoft.EntityFrameworkCore;
using OrderItem = E_commerce_API.DTOs.Order.OrderItem;
using Review = E_commerce_API.DTOs.Order.Review;

namespace E_commerce_API.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly AppDbContext _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(ICurrentUserService currentUserService, AppDbContext context , ILogger<OrderService> logger)
        {
            _currentUserService = currentUserService;
            _context = context;
            _logger = logger;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var result = await _context.Order
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    userId = o.UserId,
                    totalPrice = o.TotalPrice,
                    stutes = o.Status,
                    Address = o.ShippingAddress
                })
                .ToListAsync();

            return result;
        }



        public async Task<List<MyOrderDto>> GetMyOrders()
        {
            var result = await _context.Order
                .Where(o => o.UserId == _currentUserService.UserId)      //
                .Select(o => new MyOrderDto
                {
                    Id = o.Id,
                    Address = o.ShippingAddress,
                    stutes = o.Status
                })
                .ToListAsync();

            return result;

        }

        public async Task<MyOrderDto>? GetMyOrder(int Id)
        {
           
            var result = await _context.Order
                .Where(o =>  o.UserId == _currentUserService.UserId && o.Id == Id  )
                .Select(o => new MyOrderDto
                {
                    Id = o.Id,
                    Address = o.ShippingAddress,
                    stutes = o.Status
                })
                .FirstOrDefaultAsync();
            return result;
        }


        public async Task<List<OrderDetails>> OrderDetails()
        {
            var result = await _context.Order
                .Where(o => o.UserId == _currentUserService.UserId)
                .Select(o => new OrderDetails
                {
                    Id = o.Id,
                    Address = o.ShippingAddress,
                    userId = o.UserId,
                    stutes = o.Status,
                    OrderItems = o.OrderItems
                    .Select(oi => new OrderItem
                    {
                        ProductId = oi.ProductId,
                        quantity = oi.Quantity,
                        price = oi.PriceAtPurchase
                    })
                    .ToList(),

                    Reviews = o.Reviews
                    .Select(r => new DTOs.Order.Review
                    {
                        rate = r.Rating,
                        comment = r.Comment
                    }).ToList()
                })
                .ToListAsync();

            return result;

        }



        public async Task<bool> UpdateStatus(int OrderId)
        {
            
            var order = await _context.Order.FirstOrDefaultAsync(o => o.Id == OrderId);
            if (order == null)
            {
                _logger.LogWarning($"Order with ID {OrderId} not found. userid : {_currentUserService.UserId}");
                return false;
            }

            switch (order.Status)
            {
                case OrderStatus.Pending:
                    order.Status = OrderStatus.Processing;
                    break;

                case OrderStatus.Processing:
                    order.Status = OrderStatus.Shipped;
                    break;

                case OrderStatus.Shipped:
                    order.Status = OrderStatus.Delivered;
                    break;

                case OrderStatus.Delivered:
                    return false;

                case OrderStatus.Cancelled:
                    return false;

                default:
                    return false;
            }
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Order with ID {OrderId} status updated to {order.Status}. userid : {_currentUserService.UserId}");
            return true;
        }


        public async Task<bool> CancelOrder(int OrderId)
        {
            var order = await _context.Order
                .Include(x=> x.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == OrderId && o.UserId == _currentUserService.UserId);

            if (order == null)
            {
                _logger.LogWarning($"Order with ID {OrderId} not found or does not belong to the current user. userid : {_currentUserService.UserId}");
                return false;
            }
            if (order.Status != OrderStatus.Processing && order.Status != OrderStatus.Pending)
            {
                return false;
            }

            foreach (var item in order.OrderItems)
            {
                item.Product.Stock += item.Quantity;
            }

            order.Status = OrderStatus.Cancelled;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Order with ID {OrderId} has been cancelled. userid : {_currentUserService.UserId}");
            return true;
        }

       
    }
}
