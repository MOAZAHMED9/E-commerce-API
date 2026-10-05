using E_commerce_API.Data;
using E_commerce_API.DTOs.Common;
using E_commerce_API.DTOs.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<bool> AlterActive(int id, bool isActive)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            user.IsActive = isActive;   
            await _context.SaveChangesAsync();
            _logger.LogInformation($"User with ID {id} has been {(isActive ? "activated" : "deactivated")}.");
            return true;

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

        public async Task<PagedResultDto<UserDto>> GetAllUsersWithPagination(UserSearchQuereDto quereDto)
        {
           var query = _context.Users.AsQueryable();

            if (quereDto.IsActive.HasValue)
            {
                query = query.Where(u => u.IsActive == quereDto.IsActive);
            }

            if(!string.IsNullOrEmpty(quereDto.UserName))
            {
                query = query.Where(u => u.UserName.Contains(quereDto.UserName));
            }

            if(!string.IsNullOrEmpty(quereDto.Email))
            {
                query = query.Where(u => u.Email.Contains(quereDto.Email));
            }

            if(!string.IsNullOrEmpty(quereDto.Phone))
            {
                query = query.Where(u => u.Phone.Contains(quereDto.Phone));
            }


            if (!quereDto.sortby.IsNullOrEmpty())
            {


                switch (quereDto.sortby?.ToLower())
                {
                    case "name":
                        query = quereDto.desc ? query.OrderByDescending(u => u.UserName) : query.OrderBy(u => u.UserName);
                        break;

                    case "email":
                        query = quereDto.desc ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email);
                        break;

                    case "phone":
                        query = quereDto.desc ? query.OrderByDescending(u => u.Phone) : query.OrderBy(u => u.Phone);
                        break;

                    default:
                        query = quereDto.desc ? query.OrderByDescending(u => u.Id) : query.OrderBy(u => u.Id);
                        break;
                }
            }
            else
            {
                query = quereDto.desc ? query.OrderByDescending(u => u.Id) : query.OrderBy(u => u.Id);
            }



            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / quereDto.PageSize);

            var users = await query
                .Skip((quereDto.PageNumber - 1) * quereDto.PageSize)
                .Take(quereDto.PageSize)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Phone = u.Phone,
                    Email = u.Email,
                    IsActive = u.IsActive
                })
                .ToListAsync();
            return new PagedResultDto<UserDto>
            {
               TotalCount = totalCount,
               TotalPages = totalPages,
               pageNumber = quereDto.PageNumber,
               PageSize = quereDto.PageSize,
               Data = users
            };
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
