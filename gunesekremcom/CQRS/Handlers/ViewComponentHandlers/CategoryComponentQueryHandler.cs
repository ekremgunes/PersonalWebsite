using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class CategoryComponentQueryHandler : IRequestHandler<CategoryComponentQuery, List<CategoryComponentQueryResult>>
    {
        private readonly IUow _uow;

        public CategoryComponentQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<List<CategoryComponentQueryResult>> Handle(CategoryComponentQuery request, CancellationToken cancellationToken)
        {
            short categoryCount = 5;
            var categories = await _uow.GetRepository<Category>().GetQuery()
                .Include(x => x.Posts)
                .OrderByDescending(x => x.Posts.Count)
                .Take(categoryCount)
                .Select(x => new CategoryComponentQueryResult
                {
                    Id = x.Id,
                    Title = x.Title,
                    PostCount = x.Posts.Count
                })
                .ToListAsync();

            return categories;
        }
    }
}
