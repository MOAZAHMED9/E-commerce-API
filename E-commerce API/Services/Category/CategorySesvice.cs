using E_commerce_API.Data;
using E_commerce_API.DTOs.Category;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.Services.Category
{
    public class CategorySesvice : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CategorySesvice> _logger;

        public CategorySesvice(AppDbContext context, ILogger<CategorySesvice> logger)
        {
            _context = context;
            _logger = logger;
        }



        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categorias = await _context.Categore
                .AsNoTracking()
                .Select(s=> new CategoryDto
                {
                    Id=s.Id,
                    Name = s.Name,
                    Description= s.Description
                })
                .ToListAsync();
            
            return categorias;
         
        }

        

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            if(id < 1)
            {
                return null;
            }
            
            var caregory = await _context.Categore
                .AsNoTracking()
                .FirstOrDefaultAsync(x=> x.Id == id);

            if(caregory==null)
            {
                return null;
            }

            return new CategoryDto
            {
                Id = caregory.Id,
                Name = caregory.Name,
                Description = caregory.Description
            };

        }
        
        
        
        
        public async Task<CategoryDto> CreateCategory(CreateCategoryDto dto)
        {
            var found = await _context.Categore.AnyAsync(x=> x.Name == dto.Name);

            if(found)
            {
                return null;
            }

            var category = new Models.Categore
            {
                Name = dto.Name,
                Description = dto.Description,

            };

            await _context.Categore.AddAsync(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Category created with ID: {category.Id} ");

            return await GetCategoryById(category.Id);

        }


        public async Task<bool> UpdataCategoury(int id,UpdateCateguryDto dto)
        {
            if (id < 1)
            {
                return false;
            }

            var category = await _context.Categore.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return false;
            }

            category.Name = dto.Name;
            category.Description = dto.Description;

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Category updated with ID: {category.Id} ");
            return true;

        }




        public async Task<bool> DeleteCategory(int id)
        {
            if (id < 1)
            {
                return false;
            }

            var category = await _context.Categore
                .Include(x=> x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                _logger.LogWarning($"Category with ID: {id} not found for deletion.");
                return false;
            }

            category.IsDeleted = true;

            foreach (var product in category.Products)
            {
                product.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Category deleted with ID: {category.Id} ");
            return true;


        }




    }
}
