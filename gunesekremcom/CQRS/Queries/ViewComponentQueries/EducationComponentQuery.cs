using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class EducationComponentQuery : IRequest<List<EducationComponentQueryResult>>
    {
    }
}
