using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Users;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Auth;

public sealed class AuthMiddleware : IMiddleware
{
    private readonly IUserContext _userContext;

    public AuthMiddleware(IUserContext userContext)
    {
        _userContext = userContext;
    }

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            var token = context.Request
                .Headers["Authorization"]
                .ToString()
                .Replace("Bearer ", string.Empty);

            if (string.IsNullOrEmpty(token))
                return next(context);

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            SetUser(jsonToken?.Claims.ToList());
            return next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private void SetUser(List<Claim>? claims)
    {
        if (claims is null) return;

        try
        {
            var userId = Guid.Parse(claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            var email = claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var role = (Role)Enum.Parse(typeof(Role), claims.First(claim => claim.Type == ClaimTypes.Role).Value);

            _userContext.Populate(userId, email, role);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}