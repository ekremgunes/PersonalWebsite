using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemovePostCommand : IRequest
    {
        public int Id { get; set; }
        public RemovePostCommand(int id)
        {
            this.Id = id;
        }
    }
}
