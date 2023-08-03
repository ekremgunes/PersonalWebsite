namespace gunesekremcom.Data.Entities
{
    public class Certificate : BaseEntity
    {
        public string CredentialUrl { get; set; }
        public string Title { get; set; }
        public ushort order { get; set; }
        public string Host { get; set; }
        public string Image { get; set; }
    }
}
