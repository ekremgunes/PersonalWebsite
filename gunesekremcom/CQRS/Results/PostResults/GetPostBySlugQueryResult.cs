using gunesekremcom.Data.Entities;

namespace gunesekremcom.CQRS.Results
{
    public class GetPostBySlugQueryResult
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public uint ViewCount { get; set; }
        public ushort ReadingTime { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
