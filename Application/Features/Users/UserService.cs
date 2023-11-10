using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Abstractions.Auth;
using Application.Abstractions.Services;
using Application.Abstractions.Settings;
using Application.Database;
using Application.Features.Users.Dto;
using Domain.Abstractions.Exceptions;
using Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace Application.Features.Users;

internal sealed class UserService : IUserService
{
    private readonly TrainingDbContext _context;
    private readonly IUserContext _userContext;
    private readonly AuthSettings _authSettings;

    public UserService(TrainingDbContext context, IUserContext userContext, AuthSettings authSettings)
    {
        _context = context;
        _userContext = userContext;
        _authSettings = authSettings;
    }

    public string GetCurrentUser()
    {
        if (!_userContext.IsAuthenticated) throw new BadRequestException("User not authenticated");

        var user = _context.Users.FirstOrDefault(u => u.Id == _userContext.UserId);
        if (user is null) throw new BadRequestException("User not found");

        return GenerateToken(user);
    }

    public IEnumerable<UserDto> GetAllUsers()
    {
        var users = _context.Users.ToList();
        return users.Select(u => new UserDto
        {
            Username = u.Username,
            Email = u.Email,
            BirthDate = u.BirthDate
        });
    }

    public Guid RegisterUser(RegisterUserDto dto)
    {
        var user = User.CreateUser(dto.Username, dto.Email, dto.BirthDate, dto.Password);

        _context.Users.Add(user);
        _context.SaveChanges();

        return user.Id;
    }

    public string LoginUser(LoginUserDto dto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
        if (user is null) throw new BadRequestException("Invalid email or password");

        var isValid = user.VerifyPassword(dto.Password);
        if (!isValid) throw new BadRequestException("Invalid username or password");

        return GenerateToken(user);
    }

    public void DeleteUser(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null) throw new ApplicationException("User not found");

        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public void DeleteAccount()
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == _userContext.UserId);
        if (user is null) throw new ApplicationException("User not found");

        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    private string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString()),
            new("DateOfBirth", user.BirthDate.ToString("yy-MM-dd")),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddMinutes(_authSettings.JwtExpireMinutes);

        var token = new JwtSecurityToken(
            issuer: _authSettings.JwtIssuer,
            audience: _authSettings.JwtIssuer,
            claims: claims,
            expires: expires,
            signingCredentials: cred
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}