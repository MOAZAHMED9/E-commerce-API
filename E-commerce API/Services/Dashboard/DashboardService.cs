using E_commerce_API.Data;
using E_commerce_API.DTOs.Dashboard;
using E_commerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<DashboardDto> GetDashboardData()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalOrders = await _context.Order.CountAsync();
            var totalProducts = await _context.Products.CountAsync();
            var pendingOrders = await _context.Order.CountAsync(o => o.Status == OrderStatus.Pending);
            var deliveredOrders = await _context.Order.CountAsync(o => o.Status == OrderStatus.Delivered);
            var cancelledOrders = await _context.Order.CountAsync(o => o.Status == OrderStatus.Cancelled);
            var totalRevenue = await _context.Order.Where(x=>x.Status != OrderStatus.Cancelled).SumAsync(o => o.TotalPrice);
            var topSellingProducts = await _context.OrderItems
                .Where(oi => oi.Order.Status != OrderStatus.Cancelled)
                .GroupBy(oi => new { oi.ProductId, oi.Product.Name })
                .Select(g => new TopSellingProductDto
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.Name,
                    QuantitySold = g.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(p => p.QuantitySold)
                .Take(5)
                .ToListAsync();


            return new DashboardDto
            {
                TotalUsers = totalUsers,
                TotalOrders = totalOrders,
                TotalProducts = totalProducts,
                PendingOrders = pendingOrders,
                DeliveredOrders= deliveredOrders,
                CancelledOrders = cancelledOrders,
                TotalRevenue =totalRevenue,
                TopSellingProducts= topSellingProducts
            };
        }
    }
}
