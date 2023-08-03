using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.CertificateHandlers
{
    public class UpdateCertificateCommandHandler : IRequestHandler<UpdateCertificateCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateCertificateCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCertificateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Certificate>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                var newEntity = _mapper.Map<Certificate>(request);
                await _uow.GetRepository<Certificate>().UpdateAsync(entity, newEntity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
