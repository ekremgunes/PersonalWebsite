using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.ProjectValidations
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Boş Bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım Boş Bırakılamaz");
            RuleFor(x => x.Star).InclusiveBetween((ushort)1, (ushort)5).WithMessage("Yıldız Sayısı 1-5 arasında olmalıdır");
        }
    }
}
