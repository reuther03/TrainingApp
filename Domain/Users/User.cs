using Domain.Abstractions;

namespace Domain.Users;

public sealed class User : Entity
{
    public string Username { get; private set; } = default!;
    public DateTime BirthDate { get; private set; }

    public string Password { get; private set; } = default!;

    private User()
    {
    }

    private User(Guid id, string username, DateTime birthDate, string rawPassword) : base(id)
    {
        Username = username;
        BirthDate = birthDate;

        SetPassword(rawPassword);
    }

    /// <summary>
    /// Factory Method - metoda tworząca obiekt poprzez prywatny konstruktor
    /// </summary>
    public static User Create(string username, DateTime birthDate, string rawPassword)
    {
        var user = new User(Guid.NewGuid(), username, birthDate, rawPassword);
        return user;
    }

    public void Update(string username, DateTime birthDate)
    {
        Username = username;
        BirthDate = birthDate;
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