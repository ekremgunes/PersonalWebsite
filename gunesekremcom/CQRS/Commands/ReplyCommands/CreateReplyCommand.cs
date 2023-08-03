using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreateReplyCommand : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ReplyText { get; set; }

        public int CommentId { get; set; }
    }
}
