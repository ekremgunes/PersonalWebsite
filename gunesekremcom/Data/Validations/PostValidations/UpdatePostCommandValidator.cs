using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.PostValidations
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Boş Bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim Boş Bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Boş Bırakılamaz");
        }
    }
}
