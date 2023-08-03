namespace gunesekremcom.CQRS.Results
{
    public class GetCertificateByIdQueryResult
    {
        public int Id { get; set; }
        public string CredentialUrl { get; set; }
        public string Title { get; set; }
        public ushort order { get; set; }
        public string Host { get; set; }
        public string Image { get; set; }
    }
}
