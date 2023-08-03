using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetCertificationsQueryHandler : IRequestHandler<GetCertificationsQuery, List<GetCertificationsQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetCertificationsQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetCertificationsQueryResult>> Handle(GetCertificationsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<Certificate>().GetAllAsync();
            return _mapper.Map<List<GetCertificationsQueryResult>>(entities);
        }
    }
}
