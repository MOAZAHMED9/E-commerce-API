using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace E_commerce_API.Auth
{
    public class CustomerOwnerOrAdminHandler : AuthorizationHandler<CustomerOwnerOrAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerOwnerOrAdminRequirement requirement)
        {
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }



            var Customer = context.User.FindFirst(ClaimTypes.NameIdentifier).ToString();

            if(string.IsNullOrEmpty(Customer))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (context.Resource is HttpContext httpContext)
            {
                var routeStudentId = httpContext.Request.RouteValues["id"]?.ToString();

                // 4. نقارن
                if (Customer == routeStudentId)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;

        }
    }
}
