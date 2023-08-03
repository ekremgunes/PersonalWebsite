using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class PostComponentQueryHandler : IRequestHandler<PostComponentQuery, List<PostComponentQueryResult>>
    {
        private readonly IUow _uow;

        public PostComponentQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<List<PostComponentQueryResult>> Handle(PostComponentQuery request, CancellationToken cancellationToken)
        {
            short postCount = 8;
            var posts = await _uow.GetRepository<Post>().GetQuery()
                .OrderByDescending(x => x.ViewCount)
                .Take(postCount)
                .Select(x => new PostComponentQueryResult
                {
                    ViewCount = x.ViewCount,
                    Title = x.Title,
                    Id = x.Id,
                    Slug = x.Slug,
                    Image = x.Image,
                    ReadingTime = x.ReadingTime
                })
                .ToListAsync();
            return posts;
        }

    }
}
