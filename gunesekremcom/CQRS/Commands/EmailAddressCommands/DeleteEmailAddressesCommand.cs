using MediatR;

namespace gunesekremcom.CQRS.Commands.EmailAddressCommands
{
    public class DeleteEmailAddressesCommand : IRequest
    {
        public int[] MailIds { get; set; }
        public DeleteEmailAddressesCommand(int[] ids)
        {
            this.MailIds = ids;
        }
    }
}
