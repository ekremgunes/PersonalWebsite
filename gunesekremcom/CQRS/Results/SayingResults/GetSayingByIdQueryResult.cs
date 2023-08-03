namespace gunesekremcom.CQRS.Results
{
    public class GetSayingByIdQueryResult
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Content { get; set; }
    }
}
