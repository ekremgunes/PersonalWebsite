using FluentValidation;
using gunesekremcom.CQRS.Commands;

namespace gunesekremcom.Data.Validations.CommentValidations
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı zorunlu");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı zorunlu");
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Yorum alanı zorunlu").MaximumLength(500).WithMessage("İçerik maksimum 500 karakter uzunluğunda olabilir");
            RuleFor(x => x.PostId).NotEmpty().WithMessage("Post id bulunamadı");

        }
    }
}
