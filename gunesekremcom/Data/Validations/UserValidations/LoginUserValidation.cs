using FluentValidation;
using gunesekremcom.CQRS.Queries;

namespace gunesekremcom.Data.Validations.UserValidations
{
    public class LoginUserValidation : AbstractValidator<CheckUserQuery>
    {
        public LoginUserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage("Kullanıcı Adı Zorunlu");
            RuleFor(x => x.Password).NotEmpty().MaximumLength(100).WithMessage("Şifre Zorunlu");
        }
    }
}
