using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveEducationCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveEducationCommand(int id)
        {
            this.Id = id;
        }
    }
}
