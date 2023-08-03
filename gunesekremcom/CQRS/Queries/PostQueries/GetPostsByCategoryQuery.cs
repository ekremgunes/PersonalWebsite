using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetPostsByCategoryQuery : IRequest<List<GetPostsQueryResult>>
    {
        public string category { get; set; }
        public int? size { get; set; }
        public GetPostsByCategoryQuery(string category, int? size = 0)
        {
            this.category = category;
            this.size = size;

        }
    }
}
