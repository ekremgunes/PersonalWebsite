using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemoveCertificateCommandHandler : IRequestHandler<RemoveCertificateCommand>
    {
        private readonly IUow _uow;

        public RemoveCertificateCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(RemoveCertificateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Certificate>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Certificate>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
