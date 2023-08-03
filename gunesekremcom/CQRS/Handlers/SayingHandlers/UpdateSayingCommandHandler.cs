using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateSayingCommandHandler : IRequestHandler<UpdateSayingCommand>
    {
        private readonly IUow _uow;

        public UpdateSayingCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(UpdateSayingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Saying>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                var newSaying = new Saying { Content = request.Content, Id = request.Id, Owner = request.Owner };

                await _uow.GetRepository<Saying>().UpdateAsync(entity, newSaying);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
