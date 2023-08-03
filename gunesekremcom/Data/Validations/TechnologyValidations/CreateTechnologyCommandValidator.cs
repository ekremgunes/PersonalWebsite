using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.TechnologyValidations
{
    public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ColorCode).NotEmpty();
        }
    }
}
