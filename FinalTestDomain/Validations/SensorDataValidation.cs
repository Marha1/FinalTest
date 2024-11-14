using FluentValidation;
using FinalTestDomain.Models;
using FinalTestDomain.Primitives;

namespace FinalTestDomain.Validations
{
    public class SensorDataValidation : AbstractValidator<SensorData>
    {
        public SensorDataValidation()
        {
            RuleFor(x => x.SensorId)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty);

            RuleFor(x => x.Timestamp)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(ValidationMessages.LessThanCurrentDate);

            RuleFor(x => x.Temperature)
                .InclusiveBetween(-50, 50).WithMessage(ValidationMessages.ValueOutOfRange);

            RuleFor(x => x.Humidity)
                .InclusiveBetween(0, 100).WithMessage(ValidationMessages.ValueOutOfRange);

            RuleFor(x => x.BatteryLevel)
                .InclusiveBetween(0, 100).WithMessage(ValidationMessages.ValueOutOfRange);
        }
    }
}