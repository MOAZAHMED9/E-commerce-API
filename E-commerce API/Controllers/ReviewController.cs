using E_commerce_API.DTOs.Review;
using E_commerce_API.Services.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }




        [HttpGet]
        public async Task<ActionResult<List<ReviewDto>>> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviews();
            return Ok(reviews);
        }



        [HttpGet("{id}" , Name = "GetReviewById")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }





        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<ActionResult<ReviewDto>> CreateReview(CreateReview reviewDto)
        {
            var createdReview = await _reviewService.CreateReview(reviewDto);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.Id }, createdReview);
        }



        [Authorize(Roles = "Customer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, UpdateReviewDto reviewDto)
        {
            var result = await _reviewService.UpdateReview(id, reviewDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        [Authorize (Policy = "CustomerOwner")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await _reviewService.DeleteReview(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
