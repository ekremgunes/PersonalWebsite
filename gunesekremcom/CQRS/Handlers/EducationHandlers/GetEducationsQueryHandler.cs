using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetEducationsQueryHandler : IRequestHandler<GetEducationsQuery, List<GetEducationsQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;


        public GetEducationsQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetEducationsQueryResult>> Handle(GetEducationsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<Education>().GetAllAsync();
            return _mapper.Map<List<GetEducationsQueryResult>>(entities);
        }
    }
}
