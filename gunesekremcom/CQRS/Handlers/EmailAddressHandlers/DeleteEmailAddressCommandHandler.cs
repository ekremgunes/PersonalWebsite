using gunesekremcom.CQRS.Commands.EmailAddressCommands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.EmailAddressHandlers
{
    public class DeleteEmailAddressCommandHandler : IRequestHandler<DeleteEmailAddressCommand>
    {
        private readonly IUow _uow;

        public DeleteEmailAddressCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task Handle(DeleteEmailAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<EmailAddress>().GetByIdAsync(request.Id);
            if (entity is not null)
            {
                await _uow.GetRepository<EmailAddress>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
