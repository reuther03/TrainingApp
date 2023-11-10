using Domain.Users;

namespace Application.Abstractions.Auth;

public interface IUserContext
{
    bool IsAuthenticated { get; }
    Guid? UserId { get; set; }
    string? Email { get; set; }
    Role? Role { get; set; }

    void Populate(Guid? userId, string? email, Role? role);
}