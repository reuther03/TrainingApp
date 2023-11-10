namespace Application.Features.Users.Dto;

public class RegisterUserDto
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime BirthDate { get; set; }
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}