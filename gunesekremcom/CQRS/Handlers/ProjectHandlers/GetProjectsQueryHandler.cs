using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<GetProjectsQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetProjectsQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetProjectsQueryResult>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<Project>().GetQuery()
                .OrderBy(x => x.Order)
                .ToListAsync();
            return _mapper.Map<List<GetProjectsQueryResult>>(entities);
        }
    }
}
