using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.PostHandlers
{
    public class GetPostsByCategoryQueryHandler : IRequestHandler<GetPostsByCategoryQuery, List<GetPostsQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetPostsByCategoryQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetPostsQueryResult>> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var posts = new List<Post>();
            if (request.size == 0)
            {
                posts = await _uow.GetRepository<Post>().GetQuery()
                    .Include(x => x.Category)
                    .Where(x => x.Category.Title == request.category)
                    .ToListAsync();
            }
            else
            {
                posts = await _uow.GetRepository<Post>().GetQuery()
                    .Include(x => x.Category)
                    .Where(x => x.Category.Title == request.category)
                    .Take((int)request.size)
                    .ToListAsync();
            }

            return _mapper.Map<List<GetPostsQueryResult>>(posts);
        }
    }
}
