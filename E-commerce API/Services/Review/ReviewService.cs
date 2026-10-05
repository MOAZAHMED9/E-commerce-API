using E_commerce_API.Data;
using E_commerce_API.DTOs.Review;
using E_commerce_API.Models;
using E_commerce_API.Services.Audit;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILogger<ReviewService> _logger;    

        public ReviewService(AppDbContext context, ICurrentUserService currentUserService, ILogger<ReviewService> logger)
        {
            _context = context;
            _currentUserService = currentUserService;
            _logger = logger;
        }

        public async Task<List<ReviewDto>> GetAllReviews()
        {

            var result = await _context.Reviews
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rate = r.rate,
                    Comment = r.comment,
                    UserName = r.User.UserName,
                    CreatedAt = r.CreateAt,
                })
                .ToListAsync();

            return result;
        }


        public async Task<List<ReviewDto>> GetReviewsByProductId(int productId)
        {
            var result = await _context.Reviews
                .Where(r => r.ProductId == productId)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rate = r.rate,
                    Comment = r.comment,
                    UserName = r.User.UserName,
                    CreatedAt = r.CreateAt,
                })
                .OrderByDescending(r => r.Rate)
                .ToListAsync();

            return result;

        }

         public async Task<ReviewDto> GetReviewById(int reviewId)
         {
            
            var result = await _context.Reviews
                .Where(r => r.Id == reviewId)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Rate = r.rate,
                    Comment = r.comment,
                    UserName = r.User.UserName,
                    CreatedAt = r.CreateAt,
                })
                .FirstOrDefaultAsync();
            return result;

        }



        public async Task<ReviewDto> CreateReview(CreateReview reviewDto)
        {


            var order = await _context.Order
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == reviewDto.orderId && o.UserId == _currentUserService.UserId && o.OrderItems.Any(x => x.ProductId == reviewDto.ProductId));


            if (order == null || order.stutes != enStutes.Delivered)
            {
                return null; // order does not exist or is not delivered yet
            }

            

            var existingReview = await _context.Reviews
                .AnyAsync(r => r.ProductId == reviewDto.ProductId &&
                r.UserId == _currentUserService.UserId &&
                r.OrderId == reviewDto.orderId);


            if (existingReview)
            {
                return null; // User has already reviewed this product
            }


            var review = new Models.Review
            {
                ProductId = reviewDto.ProductId,
                UserId = _currentUserService.UserId.Value,
                rate = reviewDto.rate,
                comment = reviewDto.comment,
                OrderId = reviewDto.orderId
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Review created with ID: {ReviewId} by User: {UserId}", review.Id, _currentUserService.UserId);

            return await GetReviewById(review.Id);
        }



        public async Task<bool> UpdateReview(int reviewId, UpdateReviewDto reviewDto)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }

            review.rate = reviewDto.rate;
            review.comment = reviewDto.comment;
            await _context.SaveChangesAsync();
            _logger.LogInformation("Review updated with ID: {ReviewId} by User: {UserId}", review.Id, _currentUserService.UserId);
            return true;
        }

        public async Task<bool> DeleteReview(int reviewId)
        {
            var userId = _currentUserService.UserId;
            var review = await _context.Reviews.FirstOrDefaultAsync(x=> x.Id==reviewId && x.UserId==userId);
            if (review == null)
            {
                _logger.LogWarning("Attempt to delete review with ID: {ReviewId} by User: {UserId} failed - review not found or user not authorized", reviewId, userId);
                return false;
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Review deleted with ID: {ReviewId} by User: {UserId}", review.Id, _currentUserService.UserId);
            return true;
        }
    }
}
