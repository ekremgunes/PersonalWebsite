using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetEducationBySlugQueryHandler : IRequestHandler<GetEducationBySlugQuery, GetEducationBySlugQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetEducationBySlugQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetEducationBySlugQueryResult> Handle(GetEducationBySlugQuery request, CancellationToken cancellationToken)
        {
            var education = new GetEducationBySlugQueryResult();
            var entity = await _uow.GetRepository<Education>()
                .GetQuery()
                .FirstOrDefaultAsync(x => x.Slug == request.slug);

            if (entity != null)
            {
                education = _mapper.Map<GetEducationBySlugQueryResult>(entity);
            }
            return education;

        }
    }
}
