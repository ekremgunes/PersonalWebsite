using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.EducationValidations
{
    public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
    {
        public CreateEducationCommandValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım alanı zorunlu");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Zorunlu");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik Zorunlu");
            RuleFor(x => x.StudentCount).NotEmpty().WithMessage("Öğrenci sayısı için bir değer girin");
        }
    }
}
