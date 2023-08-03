using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results.EmailAdressResults;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.EmailAddressHandlers
{
    public class CreateEmailAddressCommandHandler : IRequestHandler<CreateEmailAddressCommand, CreateEmailAddressCommandResult>
    {
        private readonly IUow _uow;

        public CreateEmailAddressCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<CreateEmailAddressCommandResult> Handle(CreateEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var createdBefore = _uow.GetRepository<EmailAddress>()
                .GetQuery()
                .Any(x => x.Email == request.Email);
            var response = new CreateEmailAddressCommandResult();
            if (!createdBefore)
            {
                var confirmToken = Guid.NewGuid().ToString();
                await _uow.GetRepository<EmailAddress>().CreateAsync(new EmailAddress
                {
                    ConfirmCode = confirmToken,
                    Email = request.Email,
                    isConfirmed = false,
                    SubDate = DateTime.Now
                });
                await _uow.SaveChangesAsync();
                response.ConfirmCode = confirmToken;

            }
            else
            {
                response.isSubscriber = true;
            }
            return response;
        }
    }
}
