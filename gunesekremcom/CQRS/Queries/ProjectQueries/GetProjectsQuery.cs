using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetProjectsQuery : IRequest<List<GetProjectsQueryResult>>
    {
    }
}
