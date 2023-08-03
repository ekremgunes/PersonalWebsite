using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreateSayingCommandHandler : IRequestHandler<CreateSayingCommand>
    {
        private readonly IUow _uow;

        public CreateSayingCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(CreateSayingCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Saying>().CreateAsync(new Saying
            {
                Owner = request.Owner,
                Content = request.Content
            });
            await _uow.SaveChangesAsync();
        }
    }
}
