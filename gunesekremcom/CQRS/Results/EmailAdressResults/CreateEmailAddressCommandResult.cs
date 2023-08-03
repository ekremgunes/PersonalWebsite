namespace gunesekremcom.CQRS.Results.EmailAdressResults
{
    public class CreateEmailAddressCommandResult
    {
        public string? ConfirmCode { get; set; }

        public bool isSubscriber { get; set; } = false;
    }

}
