using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesQueryResult>>
    {
        private readonly IUow _uow;

        public GetCategoriesQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _uow.GetRepository<Category>().GetQuery()
                .Include(x => x.Posts)
                .Select(x => new GetCategoriesQueryResult
                {
                    Id = x.Id,
                    Title = x.Title,
                    PostCount = x.Posts.Count
                })
                .OrderByDescending(x => x.PostCount)
                .ToListAsync();

            return result;
        }
    }
}
