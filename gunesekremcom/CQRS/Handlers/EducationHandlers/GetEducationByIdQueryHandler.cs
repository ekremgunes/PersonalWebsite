using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, GetEducationByIdQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetEducationByIdQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetEducationByIdQueryResult> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
        {
            var education = new GetEducationByIdQueryResult();
            var entity = await _uow.GetRepository<Education>().GetByIdAsync(request.Id);

            if (entity != null)
            {
                education = _mapper.Map<GetEducationByIdQueryResult>(entity);
            }
            return education;

        }
    }
}
