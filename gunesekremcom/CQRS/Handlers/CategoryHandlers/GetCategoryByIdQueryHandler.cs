using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IUow _uow;

        public GetCategoryByIdQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Category>().GetQuery()
                .Include(x => x.Posts)
                .Select(x => new GetCategoryByIdQueryResult
                {
                    Title = x.Title,
                    Id = x.Id,
                    Posts = x.Posts
                }).FirstOrDefaultAsync(x => x.Id == request.Id);
            return entity;
        }
    }
}
