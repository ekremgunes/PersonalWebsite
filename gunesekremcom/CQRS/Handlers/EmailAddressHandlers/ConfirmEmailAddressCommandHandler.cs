using gunesekremcom.CQRS.Commands.EmailAddressCommands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.EmailAddressHandlers
{
    public class ConfirmEmailAddressCommandHandler : IRequestHandler<ConfirmEmailAddressCommand, ConfirmEmailAddressCommandResult>
    {
        private readonly IUow _uow;

        public ConfirmEmailAddressCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<ConfirmEmailAddressCommandResult> Handle(ConfirmEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = _uow.GetRepository<EmailAddress>()
                .GetQuery()
                .FirstOrDefault(x => x.ConfirmCode.Equals(request.ConfirmCode));

            var result = new ConfirmEmailAddressCommandResult();

            if (entity != null)
            {
                entity.isConfirmed = true;
                await _uow.SaveChangesAsync();
                result.isSucceeded = true;

            }
            else
                result.isSucceeded = false;

            return result;
        }
    }
}
