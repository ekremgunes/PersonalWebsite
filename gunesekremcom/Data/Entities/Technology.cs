namespace gunesekremcom.Data.Entities
{
    public class Technology : BaseEntity
    {
        public string Icon { get; set; }
        public string ColorCode { get; set; }
        public string Title { get; set; }
        public ushort order { get; set; }
    }
}
