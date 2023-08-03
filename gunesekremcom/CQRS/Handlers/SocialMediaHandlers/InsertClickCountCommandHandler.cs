using gunesekremcom.CQRS.Commands.SocialMediaCommands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.SocialMediaHandlers
{
    public class InsertClickCountCommandHandler : IRequestHandler<InsertClickCountCommand>
    {
        private readonly IUow _uow;

        public InsertClickCountCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(InsertClickCountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<SocialMedia>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                entity.ClickCount += 1;
                await _uow.SaveChangesAsync();
            }
        }
    }
}
