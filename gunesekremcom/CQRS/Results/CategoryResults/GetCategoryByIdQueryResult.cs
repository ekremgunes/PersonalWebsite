using gunesekremcom.Data.Entities;

namespace gunesekremcom.CQRS.Results
{
    public class GetCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
