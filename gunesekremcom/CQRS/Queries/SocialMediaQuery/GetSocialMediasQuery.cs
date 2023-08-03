using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetSocialMediasQuery : IRequest<List<GetSocialMediasQueryResult>>
    {
    }
}
