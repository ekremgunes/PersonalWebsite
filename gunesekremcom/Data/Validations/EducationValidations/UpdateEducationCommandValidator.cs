using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.EducationValidations
{
    public class UpdateEducationCommandValidator : AbstractValidator<UpdateEducationCommand>
    {
        public UpdateEducationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım alanı zorunlu");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Zorunlu");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim zorunlu");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik zorunlu");
            RuleFor(x => x.StudentCount).NotEmpty().WithMessage("Öğrenci sayısı için bir değer girin");
        }
    }
}
