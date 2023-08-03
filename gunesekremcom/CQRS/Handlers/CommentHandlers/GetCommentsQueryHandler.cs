using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.CommentHandlers
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<GetCommentsQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public GetCommentsQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetCommentsQueryResult>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<Comment>().GetAllAsync();
            return _mapper.Map<List<GetCommentsQueryResult>>(entities);
        }
    }
}
