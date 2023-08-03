using gunesekremcom.Data.Entities;

namespace gunesekremcom.CQRS.Results
{
    public class GetRepliesQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ReplyText { get; set; }
        public DateTime Date { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
