using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetCommentsQuery : IRequest<List<GetCommentsQueryResult>>
    {

    }
}
