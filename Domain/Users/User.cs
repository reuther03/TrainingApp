using Domain.Abstractions;

namespace Domain.Users;

public sealed class User : Entity
{
    public string Username { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public DateTime BirthDate { get; private set; }
    public string Password { get; private set; } = default!;
    public Role Role { get; private set; } = Role.User;


    private User()
    {
    }

    private User(Guid id, string username, string email, DateTime birthDate, string rawPassword, Role role = Role.User)
        : base(id)
    {
        Username = username;
        Email = email;
        BirthDate = birthDate;

        SetPassword(rawPassword);
    }


    /// <summary>
    /// Factory Method - metoda tworząca obiekt poprzez prywatny konstruktor
    /// </summary>
    public static User CreateUser(string username, string email, DateTime birthDate, string rawPassword)
    {
        var user = new User(Guid.NewGuid(), username, email, birthDate, rawPassword);
        return user;
    }

    public static User CreateAdmin(string username, string email, DateTime birthDate, string rawPassword)
    {
        var user = new User(Guid.NewGuid(), username, email, birthDate, rawPassword, Role.Admin);
        return user;
    }

    public void Update(string username, DateTime birthDate, string email)
    {
        Username = username;
        BirthDate = birthDate;
        Email = email;
    }

    public void SetPassword(string rawPassword)
    {
        Password = PasswordHasher.Hash(rawPassword);
    }

    public bool VerifyPassword(string rawPassword)
    {
        return PasswordHasher.Verify(Password, rawPassword);
    }
}