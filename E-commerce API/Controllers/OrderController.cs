using E_commerce_API.DTOs.Order;
using E_commerce_API.Models;
using E_commerce_API.Services.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }


        [Authorize(Roles = Roles.Customer)]
        [HttpGet("myorders")]
        public async Task<ActionResult<List<MyOrderDto>>> GetMyOrders()
        {
            var orders = await _orderService.GetMyOrders();
            return Ok(orders);
        }


        [Authorize(Roles = Roles.Customer)]
        [HttpGet("myorder/{id}")]
        public async Task<ActionResult<MyOrderDto>> GetMyOrder(int id)
        {
            var order = await _orderService.GetMyOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }



        [Authorize(Roles = Roles.Admin)]
        [HttpPut("updateStatus/{orderId}")]
        public async Task<ActionResult> UpdateStatus(int orderId)
        {
            var result = await _orderService.UpdateStatus(orderId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }




        [Authorize(Roles = Roles.Customer)]
        [HttpPut("cancelOrder/{orderId}")]
        public async Task<ActionResult> CancelOrder(int orderId)
        {
            var result = await _orderService.CancelOrder(orderId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
