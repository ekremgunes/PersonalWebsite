using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetSayingByIdQueryHandler : IRequestHandler<GetSayingByIdQuery, GetSayingByIdQueryResult>
    {
        private readonly IUow _uow;

        public GetSayingByIdQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }
        public async Task<GetSayingByIdQueryResult> Handle(GetSayingByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new GetSayingByIdQueryResult();

            var entity = await _uow.GetRepository<Saying>().GetByIdAsync(request.Id);

            if (entity is not null)
            {
                result.Content = entity.Content;
                result.Owner = entity.Owner;
                result.Id = entity.Id;
            }
            return result;
        }

    }
}
