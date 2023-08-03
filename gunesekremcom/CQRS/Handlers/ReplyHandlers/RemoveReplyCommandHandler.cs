using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.ReplyHandlers
{
    public class RemoveReplyCommandHandler : IRequestHandler<RemoveReplyCommand>
    {
        private readonly IUow _uow;

        public RemoveReplyCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveReplyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Reply>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Reply>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
