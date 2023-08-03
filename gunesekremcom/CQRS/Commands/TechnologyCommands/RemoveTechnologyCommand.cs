using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveTechnologyCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveTechnologyCommand(int id)
        {
            this.Id = id;
        }
    }
}
