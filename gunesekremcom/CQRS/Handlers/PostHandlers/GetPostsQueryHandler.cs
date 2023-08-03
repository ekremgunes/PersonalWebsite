using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<GetPostsQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetPostsQueryResult>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var entities = new List<Post>();
            if (request.pageSize != 0)
            {
                entities = await _uow.GetRepository<Post>().GetQuery()
                .Include(p => p.Category)
                .Take((int)request.pageSize!)
                .ToListAsync();
            }
            else
            {
                entities = await _uow.GetRepository<Post>().GetQuery()
                .Include(p => p.Category)
                .ToListAsync();
            }

            return _mapper.Map<List<GetPostsQueryResult>>(entities);
        }
    }
}
