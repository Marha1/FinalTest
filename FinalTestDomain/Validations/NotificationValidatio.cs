using FluentValidation;
using FinalTestDomain.Models;
using FinalTestDomain.Primitives;

namespace FinalTestDomain.Validations
{
    public class NotificationValidation : AbstractValidator<Notification>
    {
        public NotificationValidation()
        {
            RuleFor(x => x.Message)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty);

            RuleFor(x => x.Date)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(ValidationMessages.LessThanCurrentDate);
        }
    }
}