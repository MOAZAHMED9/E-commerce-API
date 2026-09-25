using E_commerce_API.Data;
using E_commerce_API.DTOs.Product;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<ProductDto>> GetAllProduct()
        {
            return await _context.Products
                 .Select(x => new ProductDto
                 {
                     Id = x.Id,
                     Name=x.Name,
                     Description= x.Description,
                     price= x.Price,
                     quantity =x.Stock,
                     isActive = x.IsAvailable,
                     Categoryname = x.Categore.Name
                     
                 })
                 .ToListAsync();

        }




        public async Task<ProductDto> GetProductById(int id)
        {
            if (id < 1)
            {
                return null;
            }


            var product = await _context.Products
                  .Select(x => new ProductDto
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Description = x.Description,
                      price = x.Price,
                      quantity = x.Stock,
                      isActive = x.IsAvailable,
                      Categoryname = x.Categore.Name
                  })
                  .FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }



        public async Task<ProductDto> CreateProduct(CreateProductDto dto)
        {
            var category = await _context.Categore.AnyAsync(x=> x.Id == dto.CategoryId);
            if (!category)
            {
                return null;
            }

            var found = await _context.Products.AnyAsync(x => x.Name == dto.Name && x.CategoreId == dto.CategoryId);

            if (found)
            {
                return null;
            }

            var product = new Models.Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price=dto.price,
                Stock = dto.quantity,
                CategoreId =dto.CategoryId,
                IsAvailable = dto.isActive,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return await GetProductById(product.Id);
             

        }



        public async Task<bool> UpdateProduct(int id, UpdateProductDto dto)
        {
            var category = await _context.Categore.AnyAsync(x => x.Id == dto.CategoryId);

            if (!category)
            {
                return false;
            }

            var found = await _context.Products.FirstOrDefaultAsync(x => x.Name == dto.Name && x.CategoreId == dto.CategoryId);

            if (found == null)
            {
                return false;
            }



            found.Name = dto.Name;
            found.Description = dto.Description;
            found.Price = dto.price;
            found.Stock = dto.quantity;
            found.CategoreId = dto.CategoryId;
            found.IsAvailable = dto.isActive;



            await _context.SaveChangesAsync();

            return true;


        }

        public async Task<bool> UpdateStock(int id, int newStock)
        {
            if (id < 1 || newStock < 0)
            {
                return false;
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            product.Stock = newStock;
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> DeleteProduct(int id)
        {
            if(id<1)
            {
                return false;
            }

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }

            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;

        }


    }
}
