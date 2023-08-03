using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveCommentCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveCommentCommand(int id)
        {
            this.Id = id;
        }
    }
}
