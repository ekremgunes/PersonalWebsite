using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class SeoComponentQueryHandler : IRequestHandler<SeoComponentQuery, SeoComponentQueryResult>
    {
        private readonly IUow _uow;

        public SeoComponentQueryHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<SeoComponentQueryResult> Handle(SeoComponentQuery request, CancellationToken cancellationToken)
        {
            var model = new SeoComponentQueryResult();
            model.SeoHTML = _uow.GetRepository<Seo>().GetQuery().First().SeoHTML;
            return model;
        }
    }
}
