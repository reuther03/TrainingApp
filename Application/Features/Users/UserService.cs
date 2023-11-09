using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
    private readonly AuthSettings _authSettings;

    public UserService(TrainingDbContext context, AuthSettings authSettings)
    {
        _context = context;
        _authSettings = authSettings;
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