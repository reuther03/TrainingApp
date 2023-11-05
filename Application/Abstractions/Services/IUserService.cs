using Application.Dto.Users;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Guid CreateUser(UserDto dto);
}