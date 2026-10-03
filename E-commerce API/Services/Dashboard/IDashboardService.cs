using E_commerce_API.DTOs.Dashboard;
using E_commerce_API.DTOs.Order;
using E_commerce_API.Models;

namespace E_commerce_API.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardData();



    }
}
