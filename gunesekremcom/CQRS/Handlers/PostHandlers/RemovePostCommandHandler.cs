using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemovePostCommandHandler : IRequestHandler<RemovePostCommand>
    {
        private readonly IUow _uow;

        public RemovePostCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Post>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Post>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
