namespace gunesekremcom.CQRS.Results
{
    public class GetUserQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
