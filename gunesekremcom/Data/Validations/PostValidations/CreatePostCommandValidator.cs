using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.PostValidations
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Boş Bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Boş Bırakılamaz");
        }
    }
}
