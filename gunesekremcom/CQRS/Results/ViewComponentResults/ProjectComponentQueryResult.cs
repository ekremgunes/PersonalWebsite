namespace gunesekremcom.CQRS.Results
{
    public class ProjectComponentQueryResult
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public ushort Star { get; set; }
        public ushort Order { get; set; }
    }
}
