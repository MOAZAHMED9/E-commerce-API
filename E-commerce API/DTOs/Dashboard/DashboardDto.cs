namespace E_commerce_API.DTOs.Dashboard
{

    public class DashboardDto
    {
        public int TotalUsers { get; set; }
        public int TotalProducts { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int PendingOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int CancelledOrders { get; set; }
        public List<TopSellingProductDto> TopSellingProducts { get; set; }
    }
    
}
