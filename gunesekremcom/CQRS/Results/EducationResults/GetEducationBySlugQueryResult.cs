namespace gunesekremcom.CQRS.Results
{
    public class GetEducationBySlugQueryResult
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string Url { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string? CouponCode { get; set; }
        public ushort Order { get; set; }
        public uint StudentCount { get; set; }
    }
}
