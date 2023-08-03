using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.PostHandlers
{
    public class LoadMorePostQueryHandler : IRequestHandler<LoadMorePostQuery, List<LoadMorePostQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;


        public LoadMorePostQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<LoadMorePostQueryResult>> Handle(LoadMorePostQuery request, CancellationToken cancellationToken)
        {
            var pageSize = 4;
            List<Post> posts = new();
            if (string.IsNullOrEmpty(request.category))
            {
                posts = await _uow.GetRepository<Post>().GetQuery()
                .OrderByDescending(x => x.ViewCount)
                .Skip((request.pageIndex - 1) * pageSize)
                .Include(x => x.Category)
                .Take(pageSize)
                .ToListAsync();
            }
            else
            {
                posts = await _uow.GetRepository<Post>().GetQuery()
                .Include(x => x.Category)
                .Where(x => x.Category.Title == request.category)
                .OrderByDescending(x => x.ViewCount)
                .Skip((request.pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            }

            return _mapper.Map<List<LoadMorePostQueryResult>>(posts);

        }
    }
}
