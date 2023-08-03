using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.EmailAdressValidations
{
    public class SendEmailsCommandValidator : AbstractValidator<SendEmailsCommand>
    {
        public SendEmailsCommandValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Konu boş bırakılamaz");
        }
    }
}
