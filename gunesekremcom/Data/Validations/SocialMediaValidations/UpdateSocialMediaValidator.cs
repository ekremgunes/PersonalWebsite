using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.SocialMediaValidations
{
    public class UpdateSocialMediaValidator : AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Icon).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
