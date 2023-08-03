using gunesekremcom.CQRS.Results.EmailAdressResults;
using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreateEmailAddressCommand : IRequest<CreateEmailAddressCommandResult>
    {
        public string Email { get; set; }


    }
}
