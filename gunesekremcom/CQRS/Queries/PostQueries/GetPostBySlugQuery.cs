using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetPostBySlugQuery : IRequest<GetPostBySlugQueryResult>
    {
        public string Slug { get; set; }
        public GetPostBySlugQuery(string slug)
        {
            this.Slug = slug;
        }
    }
}
