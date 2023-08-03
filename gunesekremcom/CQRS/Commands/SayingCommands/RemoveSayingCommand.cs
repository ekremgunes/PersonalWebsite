using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveSayingCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveSayingCommand(int id)
        {
            this.Id = id;
        }
    }
}
