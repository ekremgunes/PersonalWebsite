using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemoveTechnologyCommandHandler : IRequestHandler<RemoveTechnologyCommand>
    {
        private readonly IUow _uow;

        public RemoveTechnologyCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveTechnologyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Technology>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Technology>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }

        }
    }
}
