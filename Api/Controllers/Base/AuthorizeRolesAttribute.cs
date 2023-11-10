using Domain.Users;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers.Base;

public class AuthorizeRolesAttribute : AuthorizeAttribute
{
    public AuthorizeRolesAttribute(params Role[] roles)
    {
        Roles = string.Join(",", roles);
    }
}