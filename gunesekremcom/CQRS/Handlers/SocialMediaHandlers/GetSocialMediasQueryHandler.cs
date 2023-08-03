using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetSocialMediasQueryHandler : IRequestHandler<GetSocialMediasQuery, List<GetSocialMediasQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetSocialMediasQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetSocialMediasQueryResult>> Handle(GetSocialMediasQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<SocialMedia>().GetAllAsync();

            return _mapper.Map<List<GetSocialMediasQueryResult>>(entities.OrderBy(x => x.order).ToList());
        }
    }
}
