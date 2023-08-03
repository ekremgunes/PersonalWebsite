namespace gunesekremcom.CQRS.Results
{
    public class GetSayingsQueryResult
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Content { get; set; }
    }
}
