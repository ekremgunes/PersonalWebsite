using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.ProjectValidations
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Boş Bırakılamaz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim Alanı Boş Bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım boş bırakılamaz");
            RuleFor(x => x.Star).InclusiveBetween((ushort)1, (ushort)5).WithMessage("Yıldız Sayısı 1-5 arasında olmalıdır");

        }
    }
}
