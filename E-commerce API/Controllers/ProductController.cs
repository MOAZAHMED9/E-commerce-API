using E_commerce_API.DTOs.Category;
using E_commerce_API.DTOs.Common;
using E_commerce_API.DTOs.Product;
using E_commerce_API.DTOs.Review;
using E_commerce_API.Services.Product;
using E_commerce_API.Services.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }



        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetallProduct()
        {
            var result = await _productService.GetAllProduct();

            return Ok(result);

        }


        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }




        [Authorize(Roles = "Admin")]
        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto dto)
        {
            var result = await _productService.CreateProduct(dto);
            if (result == null)
            {
                return BadRequest(" an information is Wrong or Email is oready exist");
            }

            return CreatedAtAction("GetProductById", new { id = result.Id }, result);        //لي بنعمل كدا مش بنرجع ok
        }




        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            var result = await _productService.UpdateProduct(id, dto);

            if (!result)
            {
                return BadRequest(" an information is Wrong");
            }
            return NoContent();


        }




        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (!result)
            {
                return NotFound("Not fount this category ");
            }
            return Ok("Successe deleted ");
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateStock(int id, int newStock)
        {
            var result = await _productService.UpdateStock(id, newStock);

            if (!result)
            {
                return BadRequest("An error occurred while updating the stock quantity.");
            }

            return Ok("Update Quantity Succsessful");
        }


        [HttpGet("SearchProduct")]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> Search([FromQuery] ProductSearchQuereDto searchQuere)
        {
            var result = await _productService.Search(searchQuere);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }



        [HttpGet("{productId}/reviews")]
        public async Task<ActionResult<List<ReviewDto>>> GetReviewsByProductId(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductId(productId);
            return Ok(reviews);
        }



        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("UpdateProductAvailability/{productId}")]
        public async Task<IActionResult> UpdateProductAvailability(int productId, [FromQuery] bool isAvailable= true)
        {
            var result = await _productService.AlterActive(productId, isAvailable);
            if (!result)
            {
                return BadRequest("An error occurred while updating the product availability.");
            }

            return Ok("Product availability updated successfully.");

        }
    }
}
