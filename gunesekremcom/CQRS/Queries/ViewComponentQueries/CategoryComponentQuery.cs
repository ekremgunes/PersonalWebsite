using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class CategoryComponentQuery : IRequest<List<CategoryComponentQueryResult>>
    {
    }
}
