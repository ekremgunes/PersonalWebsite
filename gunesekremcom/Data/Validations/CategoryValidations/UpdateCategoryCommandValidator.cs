using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.CategoryValidations
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Kategori Başlığı Boş Bırakılamaz")
                .MaximumLength(50).WithMessage("Başlık Çok Uzun .Maksimum Karakter '50'");
        }
    }
}

