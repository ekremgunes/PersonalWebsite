using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.CertificateValidations
{
    public class UpdateCertificateCommandValidator : AbstractValidator<UpdateCertificateCommand>
    {
        public UpdateCertificateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(x => x.Host).NotEmpty().WithMessage("Host Boş Bırakılamaz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim Boş Bırakılamaz");
            RuleFor(x => x.CredentialUrl).NotEmpty().WithMessage("CR url Boş Bırakılamaz");
        }
    }
}
