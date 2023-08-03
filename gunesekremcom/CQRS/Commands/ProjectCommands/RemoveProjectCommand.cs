using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveProjectCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveProjectCommand(int id)
        {
            this.Id = id;
        }
    }
}
