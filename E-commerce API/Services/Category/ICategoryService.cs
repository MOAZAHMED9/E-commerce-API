using E_commerce_API.DTOs.Category;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_commerce_API.Services.Category
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateCategory(CreateCategoryDto dto);

        Task<List<CategoryDto>> GetAllCategories();

        Task<CategoryDto> GetCategoryById(int id);

        Task<bool> UpdataCategoury(int id ,UpdateCateguryDto dto);

        Task<bool> DeleteCategory(int id);


    }
}
