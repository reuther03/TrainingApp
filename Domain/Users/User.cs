using Domain.Abstractions;

namespace Domain.Users;

public sealed class User : Entity
{
    public string Username { get; private set; } = default!;
    public DateTime BirthDate { get; private set; }

    private User()
    {
    }

    private User(Guid id, string username, DateTime birthDate) : base(id)
    {
        Username = username;
        BirthDate = birthDate;
    }

    /// <summary>
    /// Factory Method - metoda tworząca obiekt poprzez prywatny konstruktor
    /// </summary>
    public static User Create(string username, DateTime birthDate)
    {
        var user = new User(Guid.NewGuid(), username, birthDate);
        return user;
    }

    public void Update(string username, DateTime birthDate)
    {
        Username = username;
        BirthDate = birthDate;
    }
}