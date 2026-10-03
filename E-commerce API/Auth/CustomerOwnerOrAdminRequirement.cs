using Microsoft.AspNetCore.Authorization;

namespace E_commerce_API.Auth
{
    public class CustomerOwnerOrAdminRequirement : IAuthorizationRequirement
    {
    }
}
