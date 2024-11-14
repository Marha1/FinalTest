using FluentValidation;
using FinalTestDomain.Models;
using FinalTestDomain.Primitives;

namespace FinalTestDomain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty);

            RuleFor(x => x.PasswordHash)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty);

            RuleFor(x => x.Email)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty)
                .EmailAddress().WithMessage(ValidationMessages.InvalidEmailFormat);
        }
    }
}