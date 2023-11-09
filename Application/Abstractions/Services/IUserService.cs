using Application.Features.Users.Dto;
using Domain.Users;

namespace Application.Abstractions.Services;

public interface IUserService
{
    // string GetCurrentUser();

    Guid RegisterUser(RegisterUserDto dto);
    string LoginUser(LoginUserDto dto);

    // string LoginUser(LoginUserDto dto);
    // TODO:
    // 1. Dodać dto {string Email, string Password}
    // 2. Dodać validator (bez sprawdzenia czy email istnieje)
    // 3. Pobrac usera z bazy na podstawie Email
    // 4. Sprawdzic czy nie jest null
    // 5. Sprawdzic czy haslo jest poprawne:
    // ⏩⏩ PasswordHasher.Verify(user.Password, dto.Password); ➡ bool
    // 6a. Jesli haslo jest poprawne to uzyc GenerateToken(user) (#3.)
    // 6b. Jesli haslo jest niepoprawne to rzucic wyjatek (BadRequestException moze byc)
    // 7. Zwrocic token
}