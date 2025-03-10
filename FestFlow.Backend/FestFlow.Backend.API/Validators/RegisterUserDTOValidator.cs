using FestFlow.Backend.API.DTO;
using FluentValidation;

namespace FestFlow.Backend.API.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDTOValidator()
        {
            RuleFor(o => o.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is required");

            RuleFor(o => o.LastName)
                .NotEmpty()
                .WithMessage("LastName is required");

            RuleFor(o => o.Email)
                .NotEmpty()
                .WithMessage("FirstName is required")
                .EmailAddress()
                .WithMessage("Entered Email is not valid");

            RuleFor(o => o.StudentEnrollmentNumber)
                .NotEmpty()
                .WithMessage("Enrollment number is required");

            RuleFor(o => o.Password)
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(o => o.BranchId)
                .NotEmpty()
                .WithMessage("Enrollment number is required");
        }
    }
}
