using E_commerce_API.DTOs.User;

namespace E_commerce_API.Services.User
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        //Task<List<UserDto>> GetAllUsersActive();
        //Task<List<UserDto>> GetAllUsersDeactive();
        Task<UserDto> GetUserById(int Id);
    }
}
