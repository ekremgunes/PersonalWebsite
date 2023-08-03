using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.SayingValidations
{
    public class CreateSayingCommandValidator : AbstractValidator<CreateSayingCommand>
    {
        public CreateSayingCommandValidator()
        {
            RuleFor(x => x.Owner).NotEmpty().WithMessage("Söz Sahibi boş bırakılamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Söz içeriği boş bırakılamaz");
        }
    }
}
