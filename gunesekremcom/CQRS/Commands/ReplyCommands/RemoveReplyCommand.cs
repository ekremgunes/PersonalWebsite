using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveReplyCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveReplyCommand(int id)
        {
            this.Id = id;
        }
    }
}
