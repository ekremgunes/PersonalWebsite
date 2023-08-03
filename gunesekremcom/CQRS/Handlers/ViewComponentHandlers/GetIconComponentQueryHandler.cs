using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class GetIconComponentQueryHandler : IRequestHandler<GetIconComponentQuery, GetIconComponentQueryResult>
    {
        private readonly IUow _uow;

        public GetIconComponentQueryHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<GetIconComponentQueryResult> Handle(GetIconComponentQuery request, CancellationToken cancellationToken)
        {
            var model = new GetIconComponentQueryResult();
            model.IconPath = _uow.GetRepository<Setting>().GetQuery().First().Icon;
            return model;
        }
    }
}
