using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.SayingValidations
{
    public class UpdateSayingCommandValidator : AbstractValidator<UpdateSayingCommand>
    {
        public UpdateSayingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Owner).NotEmpty().WithMessage("Söz Sahibi boş bırakılamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Söz içeriği boş bırakılamaz");
        }
    }
}
