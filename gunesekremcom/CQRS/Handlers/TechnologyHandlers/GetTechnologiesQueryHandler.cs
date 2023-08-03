using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetTechnologiesQueryHandler : IRequestHandler<GetTechnologiesQuery, List<GetTechnologiesQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GetTechnologiesQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetTechnologiesQueryResult>> Handle(GetTechnologiesQuery request, CancellationToken cancellationToken)
        {
            var techs = await _uow.GetRepository<Technology>().GetQuery()
                .OrderBy(x => x.order)
                .ToListAsync(CancellationToken.None);
            return _mapper.Map<List<GetTechnologiesQueryResult>>(techs);
        }
    }
}
