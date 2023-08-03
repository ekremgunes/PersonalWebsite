namespace gunesekremcom.Data.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public ushort order { get; set; }
        public uint ClickCount { get; set; }
    }
}
