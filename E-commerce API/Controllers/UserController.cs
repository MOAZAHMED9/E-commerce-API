using E_commerce_API.DTOs.Common;
using E_commerce_API.DTOs.User;
using E_commerce_API.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers([FromQuery] bool? Active)
        {
            var users = await _userService.GetAllUsers(Active);
            return Ok(users);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AlterActive(int id,  bool Active = true)
        {
            var result = await _userService.AlterActive(id, Active);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("Search")]
        public async Task<ActionResult<PagedResultDto<UserDto>>> Search([FromQuery] UserSearchQuereDto searchQuere)
        {
            var result = await _userService.GetAllUsersWithPagination(searchQuere);
            return Ok(result);
        }
    }
}
