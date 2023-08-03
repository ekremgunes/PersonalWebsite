using gunesekremcom.Data.Entities;

namespace gunesekremcom.CQRS.Results
{
    public class GetCommentsQueryResult
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
