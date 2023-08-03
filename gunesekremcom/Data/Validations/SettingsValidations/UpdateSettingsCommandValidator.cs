using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.SettingsValidations
{
    public class UpdateSettingsCommandValidator : AbstractValidator<UpdateSettingsCommand>
    {
        public UpdateSettingsCommandValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz");
            RuleFor(x => x.ProfilePhoto).NotEmpty().WithMessage("Profil resmi  boş bırakılamaz");
            RuleFor(x => x.School).NotEmpty().WithMessage("Okul boş bırakılamaz");
            RuleFor(x => x.SchoolUrl).NotEmpty().WithMessage("Okul Url  boş bırakılamaz");
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Kısa Tanım  boş bırakılamaz");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Konum boş bırakılamaz");
            RuleFor(x => x.LogoImage).NotEmpty().WithMessage("Logo  boş bırakılamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz");
            RuleFor(x => x.AboutArticle).NotEmpty().WithMessage("Profil yönlendirme yazısı  boş bırakılamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim  boş bırakılamaz");
        }
    }
}
