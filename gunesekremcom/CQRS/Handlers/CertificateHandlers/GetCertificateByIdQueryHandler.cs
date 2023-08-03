using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetCertificateByIdQueryHandler : IRequestHandler<GetCertificateByIdQuery, GetCertificateByIdQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetCertificateByIdQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetCertificateByIdQueryResult> Handle(GetCertificateByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Certificate>().GetByIdAsync(request.Id);
            return _mapper.Map<GetCertificateByIdQueryResult>(entity);
        }
    }
}
