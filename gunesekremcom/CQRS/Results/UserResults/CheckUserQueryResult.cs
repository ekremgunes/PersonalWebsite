namespace gunesekremcom.CQRS.Results.UserResults
{
    public class CheckUserQueryResult
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public bool IsExist { get; set; }

    }
}
