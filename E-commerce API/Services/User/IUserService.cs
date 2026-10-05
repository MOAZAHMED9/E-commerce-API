using E_commerce_API.DTOs.Common;
using E_commerce_API.DTOs.User;

namespace E_commerce_API.Services.User
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers(bool ? Active);
        Task<UserDto> GetUserById(int Id);

        //Task<List<UserDto>> GetAllUsersActive();
        //Task<List<UserDto>> GetAllUsersDeactive();
        Task<bool> AlterActive(int id, bool isActive);
        Task<PagedResultDto<UserDto>> GetAllUsersWithPagination(UserSearchQuereDto quereDto);
    }
}
