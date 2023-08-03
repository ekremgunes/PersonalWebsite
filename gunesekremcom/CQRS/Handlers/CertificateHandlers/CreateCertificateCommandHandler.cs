using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateCertificateCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Certificate>().CreateAsync(_mapper.Map<Certificate>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
