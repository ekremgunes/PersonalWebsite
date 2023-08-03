using gunesekremcom.CQRS.Queries.ViewComponentQueries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class GetLogoComponentQueryHandler : IRequestHandler<GetLogoComponentQuery, GetLogoComponentQueryResult>
    {
        private readonly IUow _uow;

        public GetLogoComponentQueryHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<GetLogoComponentQueryResult> Handle(GetLogoComponentQuery request, CancellationToken cancellationToken)
        {
            var settings = await _uow.GetRepository<Setting>().GetQuery().FirstOrDefaultAsync();
            var model = new GetLogoComponentQueryResult
            {
                Src = settings?.LogoImage
            };
            return model;
        }
    }
}
