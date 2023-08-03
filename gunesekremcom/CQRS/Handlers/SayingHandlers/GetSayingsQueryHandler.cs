using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetSayingsQueryHandler : IRequestHandler<GetSayingsQuery, List<GetSayingsQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetSayingsQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetSayingsQueryResult>> Handle(GetSayingsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<Saying>().GetAllAsync();
            return _mapper.Map<List<GetSayingsQueryResult>>(entities);
        }
    }
}
