using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries.EmailAddressQueries
{
    public class GetEMailAddressesQuery : IRequest<List<GetEmailAddressesQueryResult>>
    {
    }
}
