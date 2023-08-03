using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetPostBySlugQueryHandler : IRequestHandler<GetPostBySlugQuery, GetPostBySlugQueryResult>
    {
        private readonly IUow _uow;

        public GetPostBySlugQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<GetPostBySlugQueryResult> Handle(GetPostBySlugQuery request, CancellationToken cancellationToken)
        {
            var post = await _uow.GetRepository<Post>().GetQuery()
                .Include(x => x.Category)
                .Include(x => x.Comments)
                   .ThenInclude(x => x.Replies)
                .Select(x => new GetPostBySlugQueryResult
                {
                    Slug = x.Slug,
                    Category = x.Category,
                    CategoryId = x.CategoryId,
                    Content = x.Content,
                    Id = x.Id,
                    Date = x.Date,
                    ReadingTime = x.ReadingTime,
                    Title = x.Title,
                    ViewCount = x.ViewCount,
                    Image = x.Image,
                    Comments = x.Comments
                }).FirstOrDefaultAsync(x => x.Slug == request.Slug);

            return post;
        }
    }
}
