using Application.Database;
using Application.Features.Users.Dto;
using FluentValidation;

namespace Application.Features.Users.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator(TrainingDbContext dbContext)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });

        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(4);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8);

        RuleFor(r => r.ConfirmPassword)
            .Equal(r => r.Password);
    }
}