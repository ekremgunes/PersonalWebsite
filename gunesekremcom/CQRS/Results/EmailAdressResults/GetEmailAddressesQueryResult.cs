namespace gunesekremcom.CQRS.Results
{
    public class GetEmailAddressesQueryResult
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool isConfirmed { get; set; }
        public string ConfirmCode { get; set; }
        public DateTime SubDate { get; set; }
    }
}
