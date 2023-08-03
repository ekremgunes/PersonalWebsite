using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.SocialMediaValidations
{
    public class CreateSocialMediaValidator : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
