using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetTechonologyByIdQueryHandler : IRequestHandler<GetTechnologyByIdQuery, GetTechnologyByIdQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GetTechonologyByIdQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetTechnologyByIdQueryResult> Handle(GetTechnologyByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Technology>().GetByIdAsync(request.Id);
            return _mapper.Map<GetTechnologyByIdQueryResult>(entity);
        }
    }
}
