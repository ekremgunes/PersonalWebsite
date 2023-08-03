using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class LoadMorePostQuery : IRequest<List<LoadMorePostQueryResult>>
    {
        public string category { get; set; }
        public int pageIndex { get; set; }
        public LoadMorePostQuery(int pageIndex, string category)
        {
            this.category = category;
            this.pageIndex = pageIndex;
        }
    }
}
