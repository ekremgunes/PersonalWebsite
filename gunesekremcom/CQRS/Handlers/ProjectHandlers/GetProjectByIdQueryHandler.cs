using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, GetProjectByIdQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetProjectByIdQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetProjectByIdQueryResult> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Project>().GetByIdAsync(request.Id);
            var result = new GetProjectByIdQueryResult();

            if (entity != null)
            {
                result = _mapper.Map<GetProjectByIdQueryResult>(entity);
            }
            return result;
        }
    }
}
