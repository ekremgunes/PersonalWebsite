using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.ReplyHandlers
{
    public class GetRepliesQueryHandler : IRequestHandler<GetRepliesQuery, List<GetRepliesQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetRepliesQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetRepliesQueryResult>> Handle(GetRepliesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<Reply>().GetAllAsync();
            return _mapper.Map<List<GetRepliesQueryResult>>(entities);

        }
    }
}
