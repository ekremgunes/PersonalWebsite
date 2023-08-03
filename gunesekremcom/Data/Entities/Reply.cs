namespace gunesekremcom.Data.Entities
{
    public class Reply : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ReplyText { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
