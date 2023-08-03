using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemoveSayingCommandHandler : IRequestHandler<RemoveSayingCommand>
    {
        private readonly IUow _uow;

        public RemoveSayingCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveSayingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Saying>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Saying>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
