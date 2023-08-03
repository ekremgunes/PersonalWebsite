namespace gunesekremcom.Data.Entities
{
    public class EmailAddress : BaseEntity
    {
        public string Email { get; set; }
        public bool isConfirmed { get; set; }
        public string ConfirmCode { get; set; }
        public DateTime SubDate { get; set; }
    }
}
