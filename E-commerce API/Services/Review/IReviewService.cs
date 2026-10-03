using E_commerce_API.DTOs.Review;

namespace E_commerce_API.Services.Review
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetAllReviews();
        Task<List<ReviewDto>> GetReviewsByProductId(int productId);
        Task<ReviewDto> GetReviewById(int reviewId);
        Task<ReviewDto> CreateReview(CreateReview reviewDto);
        Task<bool> UpdateReview(int reviewId, UpdateReviewDto reviewDto);
        Task<bool> DeleteReview(int reviewId);
    }
}
