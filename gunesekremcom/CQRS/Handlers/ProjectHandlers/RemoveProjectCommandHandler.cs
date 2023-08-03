using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemoveProjectCommandHandler : IRequestHandler<RemoveProjectCommand>
    {
        private readonly IUow _uow;

        public RemoveProjectCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Project>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Project>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
