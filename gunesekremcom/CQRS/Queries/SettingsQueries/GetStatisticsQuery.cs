using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries.SettingsQueries
{
    public class GetStatisticsQuery : IRequest<GetStatisticsQueryResult>
    {
    }
}
