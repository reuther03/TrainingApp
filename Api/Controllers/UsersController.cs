using Api.Controllers.Base;
using Application.Abstractions.Services;
using Application.Features.Users.Dto;
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
}