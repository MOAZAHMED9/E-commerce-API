using E_commerce_API.Data;
using E_commerce_API.DTOs.User;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_API.Services.User
{
    public class UserService : IUserService
    {
        //private readonly ICurrentUserService _currentUserService;
        private readonly AppDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(AppDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<List<UserDto>> GetAllUsers(bool? Active)
        {
            var query = _context.Users.AsQueryable();
            if (Active.HasValue)
            {
                query = query.Where(u => u.IsActive == Active);
            }


            return await query
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Phone = u.Phone,
                    Email = u.Email,
                    IsActive = u.IsActive
                })
                .ToListAsync();
 
        }
        

        //public async Task<List<UserDto>> GetAllUsersActive()
        //{

        //    var result = await _context.Users
        //        .Where(u => u.IsActive)
        //        .Select(u => new UserDto
        //        {
        //            Id = u.Id,
        //            UserName = u.UserName,
        //            Phone = u.Phone,
        //            Email = u.Email,
        //            IsActive = u.IsActive
        //        })
        //        .ToListAsync();
        //    return result;

        //}

        //public async Task<List<UserDto>> GetAllUsersDeactive()
        //{
        //    var result = await _context.Users
        //       .Where(u => !u.IsActive)
        //       .Select(u => new UserDto
        //       {
        //           Id = u.Id,
        //           UserName = u.UserName,
        //           Phone = u.Phone,
        //           Email = u.Email,
        //           IsActive = u.IsActive
        //       })
        //       .ToListAsync();
        //    return result;
        //}



        public async Task<UserDto> GetUserById(int Id)
        {
            var result = await _context.Users
                .Where(u => u.Id == Id)
                 .Select(u => new UserDto
                 {
                     Id = u.Id,
                     UserName = u.UserName,
                     Phone = u.Phone,
                     Email = u.Email,
                     IsActive = u.IsActive
                 })
                 .FirstOrDefaultAsync();
            return result;
        }
    }
}
