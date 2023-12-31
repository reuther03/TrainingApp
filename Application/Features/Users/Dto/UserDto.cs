﻿namespace Application.Features.Users.Dto;

public class UserDto
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime BirthDate { get; set; }
}