using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetSeoQueryHandler : IRequestHandler<GetSeoQuery, GetSeoQueryResult>
    {
        private readonly IUow _uow;

        public GetSeoQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<GetSeoQueryResult> Handle(GetSeoQuery request, CancellationToken cancellationToken)
        {
            return await _uow.GetRepository<Seo>().GetQuery()
                .Select(x => new GetSeoQueryResult
                {
                    SeoHTML = x.SeoHTML
                }).FirstAsync();
        }
    }
}
