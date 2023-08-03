using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IUow _uow;

        public RemoveSocialMediaCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<SocialMedia>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<SocialMedia>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
