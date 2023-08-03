using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemoveEducationCommandHandler : IRequestHandler<RemoveEducationCommand>
    {
        private readonly IUow _uow;

        public RemoveEducationCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveEducationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Education>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Education>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
