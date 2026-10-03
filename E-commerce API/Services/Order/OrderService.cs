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

        public OrderService(ICurrentUserService currentUserService, AppDbContext context)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var result = await _context.Order
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    userId = o.UserId,
                    totalPrice = o.totalPrice,
                    stutes = o.stutes,
                    Address = o.shippingAddress
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
                    Address = o.shippingAddress,
                    stutes = o.stutes
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
                    Address = o.shippingAddress,
                    stutes = o.stutes
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
                    Address = o.shippingAddress,
                    userId = o.UserId,
                    stutes = o.stutes,
                    OrderItems = o.OrderItems
                    .Select(oi => new OrderItem
                    {
                        ProductId = oi.ProductId,
                        quantity = oi.Quantity,
                        price = oi.priceAtPurchase
                    })
                    .ToList(),

                    Reviews = o.Reviews
                    .Select(r => new DTOs.Order.Review
                    {
                        rate = r.rate,
                        comment = r.comment
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
                return false;
            }

            switch (order.stutes)
            {
                case enStutes.Pending:
                    order.stutes = enStutes.Processing;
                    break;

                case enStutes.Processing:
                    order.stutes = enStutes.Shipped;
                    break;

                case enStutes.Shipped:
                    order.stutes = enStutes.Delivered;
                    break;

                case enStutes.Delivered:
                    return false;

                case enStutes.Cancelled:
                    return false;

                default:
                    return false;
            }
            await _context.SaveChangesAsync();
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
                return false;
            }
            if (order.stutes == enStutes.Delivered || order.stutes == enStutes.Cancelled)
            {
                return false;
            }

            foreach (var item in order.OrderItems)
            {
                item.Product.Stock += item.Quantity;
            }

            order.stutes = enStutes.Cancelled;
            await _context.SaveChangesAsync();
            return true;
        }

       
    }
}
