using E_commerce_API.Data;
using E_commerce_API.DTOs.Category;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.Services.Category
{
    public class CategorySesvice : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategorySesvice(AppDbContext context)
        {
            _context = context;
        }


      
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categorias = await _context.Categore
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
            
            var caregory = await _context.Categore.FirstOrDefaultAsync(x=> x.Id == id);

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
                return false;
            }

            category.IsDeleted = true;

            foreach (var product in category.Products)
            {
                product.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return true;


        }




    }
}
