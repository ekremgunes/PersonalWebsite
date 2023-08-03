using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetRepliesQuery : IRequest<List<GetRepliesQueryResult>>
    {

    }
}
