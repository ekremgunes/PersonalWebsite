using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetEducationsQuery : IRequest<List<GetEducationsQueryResult>>
    {
    }
}
