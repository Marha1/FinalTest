using FluentValidation;
using FinalTestDomain.Models;
using FinalTestDomain.Primitives;

namespace FinalTestDomain.Validations
{
    public class SensorValidation : AbstractValidator<Sensor>
    {
        public SensorValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty);

            RuleFor(x => x.MinValue)
                .LessThan(x => x.MaxValue).WithMessage(ValidationMessages.MinLessThanMax);

            RuleFor(x => x.BatteryLevel)
                .InclusiveBetween(0, 100).WithMessage(ValidationMessages.ValueOutOfRange);
        }
    }
}