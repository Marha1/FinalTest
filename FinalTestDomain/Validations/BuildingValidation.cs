using FluentValidation;
using FinalTestDomain.Models;
using FinalTestDomain.Primitives;

namespace FinalTestDomain.Validations
{
    public class BuildingValidation : AbstractValidator<Building>
    {
        public BuildingValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty);

            RuleFor(x => x.Address)
                .NotNull().WithMessage(ValidationMessages.NotNullOrEmpty)
                .NotEmpty().WithMessage(ValidationMessages.NotNullOrEmpty);
        }
    }
}