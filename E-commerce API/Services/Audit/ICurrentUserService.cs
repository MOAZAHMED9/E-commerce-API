namespace E_commerce_API.Services.Audit
{
    public interface ICurrentUserService
    {
        int? UserId { get; }

        string? UserName { get; }

    }
}
