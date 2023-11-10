using Domain.Users;

namespace Application.Abstractions.Auth;

internal sealed class UserContext : IUserContext
{
    public bool IsAuthenticated => UserId.HasValue;
    public Guid? UserId { get; set; }
    public string? Email { get; set; }
    public Role? Role { get; set; }

    /// <summary>
    /// Metoda wypełniająca kontekst użytkownika
    /// </summary>
    /// <param name="userId">Id użytkownika</param>
    /// <param name="email">Email użytkownika</param>
    /// <param name="role">Rola użytkownika</param>
    public void Populate(Guid? userId, string? email, Role? role)
    {
        UserId = userId;
        Email = email;
        Role = role;
    }
}