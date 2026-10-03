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

        public ReviewService(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<ReviewDto>> GetAllReviews()
        {

            var result = await _context.Reviews
                .Select(r => new ReviewDto
                {
                    OrderId = r.Id,
                    ProductId = r.ProductId,
                    UserId = r.UserId,
                    rate = r.rate,
                    comment = r.comment
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
                    OrderId = r.Id,
                    ProductId = r.ProductId,
                    UserId = r.UserId,
                    rate = r.rate,
                    comment = r.comment
                })
                .ToListAsync();

            return result;

        }

         public async Task<ReviewDto> GetReviewById(int reviewId)
         {
            
            var result = await _context.Reviews
                .Where(r => r.Id == reviewId)
                .Select(r => new ReviewDto
                {
                    OrderId = r.Id,
                    ProductId = r.ProductId,
                    UserId = r.UserId,
                    rate = r.rate,
                    comment = r.comment
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
            return true;
        }
    }
}
