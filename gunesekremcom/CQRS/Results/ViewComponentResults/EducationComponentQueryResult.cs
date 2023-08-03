namespace gunesekremcom.CQRS.Results
{
    public class EducationComponentQueryResult
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string Slug { get; set; }
        public ushort Order { get; set; }

        public uint StudentCount { get; set; }
        public uint ViewCount { get; set; }
    }
}
