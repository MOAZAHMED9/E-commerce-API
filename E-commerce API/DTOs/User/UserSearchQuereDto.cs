using System.ComponentModel.DataAnnotations;

namespace E_commerce_API.DTOs.User
{
    public class UserSearchQuereDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? IsActive { get; set; }

        public string? sortby { get; set; }
        public bool desc { get; set; } = false;

        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; } = 1;
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; } = 10;
    }
}
