using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.EmailAdressValidations
{
    public class CreateEmailAdressCommandValidator : AbstractValidator<CreateEmailAddressCommand>
    {
        public CreateEmailAdressCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Boş Bırakılamaz")
                .When(x => x.Email.Length > 3).EmailAddress().WithMessage("Gerçek Bir Mail Adresi Kullanın");
        }
    }
}
