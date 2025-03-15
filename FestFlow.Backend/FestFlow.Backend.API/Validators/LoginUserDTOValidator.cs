using FestFlow.Backend.API.DTO;
using FluentValidation;

namespace FestFlow.Backend.API.Validators
{
    public class LoginUserDTOValidator : AbstractValidator<LoginUserDTO>
    {
        public LoginUserDTOValidator()
        {
            RuleFor(o => o.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Entered Email is not valid");

            RuleFor(o => o.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
