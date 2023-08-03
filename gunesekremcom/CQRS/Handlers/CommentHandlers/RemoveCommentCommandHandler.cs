using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.CommentHandlers
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly IUow _uow;

        public RemoveCommentCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Comment>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Comment>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
