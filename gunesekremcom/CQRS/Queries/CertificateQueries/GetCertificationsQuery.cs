using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetCertificationsQuery : IRequest<List<GetCertificationsQueryResult>>
    {
    }
}
