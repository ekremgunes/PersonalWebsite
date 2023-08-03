using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetSeoQuery : IRequest<GetSeoQueryResult>
    {
        public string SeoHTML { get; set; }
    }
}
