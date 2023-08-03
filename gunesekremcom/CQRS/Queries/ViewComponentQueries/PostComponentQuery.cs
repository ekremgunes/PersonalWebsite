using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class PostComponentQuery : IRequest<List<PostComponentQueryResult>>
    {
    }
}
