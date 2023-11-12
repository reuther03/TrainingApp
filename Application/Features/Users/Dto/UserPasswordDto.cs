namespace Application.Features.Users.Dto;

public class UserPasswordDto
{
    public string CurrentPassword { get; set; } = default!;
    public string Password { get; set; } = default!;
}