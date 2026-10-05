using E_commerce_API.Data;
using E_commerce_API.DTOs.Common;
using E_commerce_API.DTOs.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_commerce_API.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(AppDbContext context , ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public async Task<List<ProductDto>> GetAllProduct()
        {
            return await _context.Products
                 .AsNoTracking()
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
                .AsNoTracking()
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
                _logger.LogWarning("Category with ID {CategoryId} does not exist.", dto.CategoryId);
                return null;
            }

            var found = await _context.Products.AnyAsync(x => x.Name == dto.Name && x.CategoreId == dto.CategoryId);

            if (found)
            {
                _logger.LogWarning("Product with name {ProductName} already exists in category {CategoryId}.", dto.Name, dto.CategoryId);
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
            _logger.LogInformation("Product created with ID: {ProductId}", product.Id);

            return await GetProductById(product.Id);
             

        }



        public async Task<bool> UpdateProduct(int id, UpdateProductDto dto)
        {
            var category = await _context.Categore.AnyAsync(x => x.Id == dto.CategoryId);

            if (!category)
            {

                return false;
            }

            var found = await _context.Products.FirstOrDefaultAsync(x => x.Id == id && x.CategoreId == dto.CategoryId);

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
            _logger.LogInformation($"Product updated with ID: {found.Id}");

            return true;


        }

        public async Task<bool> UpdateStock(int id, int newStock)
        {
            if (id < 1 || newStock < 0)
            {
                return false;
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID: {id} not found for stock update.");
                return false;
            }

            product.Stock = newStock;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product stock updated with ID: {product.Id}");
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
                _logger.LogWarning($"Product with ID: {id} not found for deletion.");
                return false;
            }

            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product deleted with ID: {product.Id}");
            return true;

        }

        public async Task<PagedResultDto<ProductDto>> Search(ProductSearchQuereDto searchQuere)
        {
            var quere = _context.Products.AsQueryable();

            if(!string.IsNullOrEmpty(searchQuere.Search))
            {
                quere = quere
                    .Where(s=> s.Name .Contains(searchQuere.Search));
            }

            if(searchQuere.isAvailable)
            {
                quere = quere.Where(s => s.IsAvailable);
            }

            if(searchQuere.maxprice!=null)
            {
                quere = quere.Where(x => x.Price <= searchQuere.maxprice);
            }

            if(searchQuere.minprice!=null)
            {
                quere = quere.Where(x => x.Price >= searchQuere.minprice);
            }

            if(searchQuere.id!=null)
            {
                quere = quere.Where(x=> x.Id == searchQuere.id);
            }



            if(!string.IsNullOrEmpty(searchQuere.orderby))
            {
                switch (searchQuere.orderby.ToLower())
                {
                    case "name":
                        quere = searchQuere.desc? 
                            quere.OrderByDescending(x => x.Name) 
                            : quere.OrderBy(x => x.Name);
                        break;



                    case "price":

                        quere = searchQuere.desc?
                             quere.OrderByDescending(s => s.Price)
                            : quere.OrderBy(s => s.Price);

                        break;

                    case "quantity":
            
                        quere = searchQuere.desc?
                             quere.OrderByDescending(s => s.Stock)
                            : quere.OrderBy(s => s.Stock);
                        break;


                }
            }
            else
            {
                quere = quere.OrderBy(s => s.Id);
            }

            var totalcount = await quere.CountAsync();

            var pagenumber = searchQuere.pagenumber <1? 1 : searchQuere.pagenumber;

            var totalpage = (int)Math.Ceiling((double)totalcount/searchQuere.pagesize);

            var data= await quere
                .Skip((pagenumber - 1) * searchQuere.pagesize)
                .Take(searchQuere.pagesize)
                .Select(s => new ProductDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    price= s.Price,
                    Description = s.Description,
                    quantity= s.Stock,
                    isActive= s.IsAvailable,
                    Categoryname = s.Categore.Name

                })
                .ToListAsync();

            return new PagedResultDto<ProductDto>
            {
                pageNumber = pagenumber,
                PageSize = searchQuere.pagesize,
                TotalCount = totalcount,
                TotalPages = totalpage,
                Data = data
            };
        }

        public async Task<bool> AlterActive(int id, bool isActive)
        {
            if (id < 1 )
            {
                return false;
            }
            
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID: {id} not found for active status update.");
                return false;
            }

            product.IsAvailable = isActive;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product active status updated with ID: {product.Id}");
            return true;
        }

    }
}
