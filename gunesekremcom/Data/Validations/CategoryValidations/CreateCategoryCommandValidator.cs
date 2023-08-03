using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.CategoryValidations
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Kategori Başlığı Boş Bırakılamaz")
                .MaximumLength(50).WithMessage("Başlık Çok Uzun .Maksimum Karakter '50'");
        }
    }
}
