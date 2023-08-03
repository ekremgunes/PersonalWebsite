using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreateCommentCommand : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }

        public int PostId { get; set; }
    }
}
