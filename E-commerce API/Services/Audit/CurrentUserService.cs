using System.Security.Claims;

namespace E_commerce_API.Services.Audit
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
         
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }


        public int? UserId
        {
            get
            {
                var userId = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

                if (int.TryParse(userId, out var id))
                {
                    return id;
                }

                return null;
            }
        }


        public string? UserName => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);  // لو اي طلب غلط رجع null

        
    }
}
