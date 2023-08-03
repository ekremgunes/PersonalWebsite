using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetPostsQuery : IRequest<List<GetPostsQueryResult>>
    {
        public int? pageSize { get; set; }
        public GetPostsQuery(int? size = 0)
        {
            pageSize = size;
        }
    }
}
