namespace gunesekremcom.Data.Entities
{
    public class Comment : BaseEntity
    {
        public DateTime Date { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
