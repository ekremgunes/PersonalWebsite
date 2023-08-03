using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.UserValidations
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Email).MinimumLength(4).MaximumLength(100).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(4).MaximumLength(100).NotEmpty();
            RuleFor(x => x.NewPassword).MinimumLength(4).MaximumLength(100);
            RuleFor(x => x.Password).MinimumLength(4).MaximumLength(100).NotEmpty();
        }
    }
}
