using E_commerce_API.DTOs.Product;
using E_commerce_API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_commerce_API.Services.Product
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProduct();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateProduct(CreateProductDto dto);
        Task<bool> UpdateProduct( int id,UpdateProductDto dto);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateStock(int id , int newStock);

       
    }
}
