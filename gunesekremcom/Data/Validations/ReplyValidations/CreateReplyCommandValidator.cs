using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.ReplyValidations
{
    public class CreateReplyCommandValidator : AbstractValidator<CreateReplyCommand>
    {
        public CreateReplyCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı zorunlu");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı zorunlu");
            RuleFor(x => x.ReplyText).NotEmpty().WithMessage("Yanıt alanı zorunlu").MaximumLength(500).WithMessage("İçerik maksimum 500 karakter uzunluğunda olabilir");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("Yorum id bulunamadı");
        }
    }
}
