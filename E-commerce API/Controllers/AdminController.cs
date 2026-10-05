using E_commerce_API.DTOs.Dashboard;
using E_commerce_API.Services.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IDashboardService _db;
        public AdminController(IDashboardService db)
        {
            _db = db;
        }

        [HttpGet("GetDashboardData")]
        public async Task<ActionResult<DashboardDto>> GetDashboardData()
        {
            var result = await _db.GetDashboardData();
            return Ok(result);
        }

        
    }
}
