using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetEducationBySlugQuery : IRequest<GetEducationBySlugQueryResult>
    {
        public string slug { get; set; }
        public GetEducationBySlugQuery(string slug)
        {
            this.slug = slug;
        }
    }
}
