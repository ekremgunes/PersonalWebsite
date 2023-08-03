namespace gunesekremcom.CQRS.Results
{
    public class PostComponentQueryResult
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public uint ViewCount { get; set; }
        public ushort ReadingTime { get; set; }

    }
}
