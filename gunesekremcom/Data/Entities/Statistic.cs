namespace gunesekremcom.Data.Entities
{
    public class Statistic : BaseEntity
    {
        public DateTime Date { get; set; }
        public uint VisitorCount { get; set; }
    }
}
