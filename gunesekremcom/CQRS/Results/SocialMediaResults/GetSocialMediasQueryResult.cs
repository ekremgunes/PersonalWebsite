namespace gunesekremcom.CQRS.Results
{
    public class GetSocialMediasQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Icon { get; set; }
        public string Url { get; set; }
        public ushort order { get; set; }
        public uint ClickCount { get; set; }
    }
}
