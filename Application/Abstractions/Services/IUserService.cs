using Application.Features.Users.Dto;
using Domain.Users;

namespace Application.Abstractions.Services;

public interface IUserService
{
    string GetCurrentUser();
    IEnumerable<UserDto> GetAllUsers();
    Guid RegisterUser(RegisterUserDto dto);
    string LoginUser(LoginUserDto dto);
    Guid UpdateUser(UserDto dto);
    void DeleteUser(Guid id);
    void DeleteAccount();
}