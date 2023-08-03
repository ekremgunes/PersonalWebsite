using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Commands.EmailAddressCommands
{
    public class ConfirmEmailAddressCommand : IRequest<ConfirmEmailAddressCommandResult>
    {
        public string ConfirmCode { get; set; }
        public ConfirmEmailAddressCommand(string confirmCode = "")
        {
            this.ConfirmCode = confirmCode;
        }
    }
}
