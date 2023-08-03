using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class SayingComponentQueryHandler : IRequestHandler<SayingComponentQuery, SayingComponentQueryResult>
    {
        private readonly IUow _uow;

        public SayingComponentQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<SayingComponentQueryResult> Handle(SayingComponentQuery request, CancellationToken cancellationToken)
        {
            var saying = await _uow.GetRepository<Saying>().GetQuery()
                .OrderBy(x => Guid.NewGuid())
                .Select(x => new SayingComponentQueryResult
                {
                    Content = x.Content,
                    Owner = x.Owner
                })
                .FirstOrDefaultAsync();
            return saying;

        }
    }
}
