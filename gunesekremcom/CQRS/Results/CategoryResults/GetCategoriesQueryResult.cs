namespace gunesekremcom.CQRS.Results
{
    public class GetCategoriesQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PostCount { get; set; } = 0;
    }
}
