using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class AboutComponentQueryHandler : IRequestHandler<AboutComponentQuery, AboutComponentQueryResult>
    {
        private readonly IUow _uow;

        public AboutComponentQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<AboutComponentQueryResult> Handle(AboutComponentQuery request, CancellationToken cancellationToken)
        {
            var text = _uow.GetRepository<Setting>().GetQuery().First().AboutArticle;
            return new AboutComponentQueryResult { AboutText = text };
        }
    }
}
