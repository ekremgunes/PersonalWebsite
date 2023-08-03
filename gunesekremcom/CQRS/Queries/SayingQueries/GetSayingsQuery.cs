using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetSayingsQuery : IRequest<List<GetSayingsQueryResult>>
    {
    }
}
