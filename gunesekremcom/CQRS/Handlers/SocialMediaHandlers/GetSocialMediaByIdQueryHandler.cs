using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetSocialMediaByIdQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<SocialMedia>().GetByIdAsync(request.Id);
            var socialMedia = new GetSocialMediaByIdQueryResult();

            if (entity != null)
            {
                socialMedia = _mapper.Map<GetSocialMediaByIdQueryResult>(entity);
            }
            return socialMedia;

        }
    }
}
