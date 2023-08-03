using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.TechnologyValidations
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Icon).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ColorCode).NotEmpty();
        }
    }
}
