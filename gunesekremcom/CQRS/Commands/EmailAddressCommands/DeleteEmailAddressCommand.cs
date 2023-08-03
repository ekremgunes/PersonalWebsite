using MediatR;

namespace gunesekremcom.CQRS.Commands.EmailAddressCommands
{
    public class DeleteEmailAddressCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteEmailAddressCommand(int id)
        {
            this.Id = id;
        }
    }
}
