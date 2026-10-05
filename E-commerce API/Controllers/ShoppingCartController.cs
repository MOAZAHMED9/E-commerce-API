using E_commerce_API.DTOs.ShoppingCart;
using E_commerce_API.Services.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Coustomer")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("GetMyCart")]
        public async Task<ActionResult<ShoppingCartDto>> GetMyCart()
        {
            var result = await _shoppingCartService.GetMyCart();
            return Ok(result);

        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(int id, int quantity)
        {
            var result = await _shoppingCartService.AddProduct(id, quantity);
            if (!result)
            {
                return BadRequest("Product or Quantity is Wrong");
            }

            return Ok("Done ");

        }



        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity(int Productid, int quantity)
        {
            var result = await _shoppingCartService.AddProduct(Productid, quantity);
            if (!result)
            {
                return BadRequest("Product or Quantity is Wrong");
            }

            return NoContent();

        }


        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            var result = await _shoppingCartService.DeleteProduct(ProductId);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("ClearCart")]
        public async Task<IActionResult> ClearCart()
        {
            var result = await _shoppingCartService.ClearCart();
            
            return NoContent();
        }

        [HttpPost("Chickout")]
        public async Task<IActionResult> Checkout([FromBody] string Address)
        {
            var result = await _shoppingCartService.CheckoutAsync(Address);
            if (result==null)
            {
                return BadRequest("Checkout failed.");
            }
            return Ok(result);
        }

    }
}
