using gunesekremcom.CQRS.Results;

namespace gunesekremcom.ViewModels
{
    public class BlogViewModel
    {
        public List<GetCategoriesQueryResult>? Categories { get; set; }
        public List<GetPostsQueryResult>? Posts { get; set; }
        public string? CategoryName { get; set; }
    }
}
