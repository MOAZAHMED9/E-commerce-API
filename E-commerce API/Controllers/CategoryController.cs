using E_commerce_API.DTOs.Category;
using E_commerce_API.Services.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("GetallCategory")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetallCategory()
        {

            var result = await _categoryService.GetAllCategories();
            
            return Ok(result);


        }




        [HttpGet("{id}" ,Name ="GetById")]
        public async Task<ActionResult<CategoryDto>> GetcategoryById(int id)
        {
            var result = await _categoryService.GetCategoryById(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }




        [Authorize(Roles ="Admin")]
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody]CreateCategoryDto dto)
        {
            var result = await _categoryService.CreateCategory(dto);
            if (result == null)
            {
                return BadRequest(" an information is Wrong or Email is oready exist");
            }

            return CreatedAtAction("GetById", new { id = result.Id }, result);        //لي بنعمل كدا مش بنرجع ok
        }




        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int id,[FromBody] UpdateCateguryDto dto)
        {
            var result = await _categoryService.UpdataCategoury(id, dto);

            if(!result)
            {
                return BadRequest(" an information is Wrong");
            }
            return NoContent();


        }



        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);

            if (!result)
            {
                return NotFound("Not fount this category ");
            }
            return Ok("Successe deleted ");
        }
    }
}
