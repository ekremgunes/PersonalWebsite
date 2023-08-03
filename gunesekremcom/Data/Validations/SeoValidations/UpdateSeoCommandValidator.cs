using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.SeoValidations
{
    public class UpdateSeoCommandValidator : AbstractValidator<UpdateSeoCommand>
    {
        public UpdateSeoCommandValidator()
        {
            RuleFor(x => x.SeoHTML).NotEmpty().WithMessage("Seo boş bırakılamaz");
        }
    }
}
