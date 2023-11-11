using Api.Controllers.Base;
using Application.Abstractions.Services;
using Application.Features.Users.Dto;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("current")]
    [Authorize]
    public ActionResult<string> GetCurrentUser()
    {
        var result = _userService.GetCurrentUser();
        return Ok(result);
    }

    [HttpGet]
    [AuthorizeRoles(Role.Admin)]
    public ActionResult<IEnumerable<UserDto>> GetAllUsers()
    {
        var result = _userService.GetAllUsers();
        return Ok(result);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
    {
        var result = _userService.RegisterUser(dto);
        return Ok(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public ActionResult LoginUser([FromBody] LoginUserDto dto)
    {
        var result = _userService.LoginUser(dto);
        return Ok(result);
    }

    [HttpPatch("update")]
    [Authorize]
    public ActionResult UpdateUser([FromBody] UserDto dto)
    {
        _userService.UpdateUser(dto);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [AuthorizeRoles(Role.Admin)]
    public ActionResult DeleteUser([FromRoute] Guid id)
    {
        _userService.DeleteUser(id);
        return NotFound();
    }

    [HttpDelete("delete-account")]
    [Authorize]
    public ActionResult DeleteAccount()
    {
        _userService.DeleteAccount();
        return Ok();
    }
}