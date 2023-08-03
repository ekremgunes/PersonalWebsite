using gunesekremcom.Models;

namespace gunesekremcom.CQRS.Results
{
    public class GetStatisticsQueryResult
    {
        public Dictionary<string, uint>? SocialMediaStats { get; set; }
        public List<StatisticModel>? VisitorStats { get; set; }
        public uint TotalVisitorCount { get; set; }
        public uint TotalPostCount { get; set; }
        public uint TotalProjectCount { get; set; }
        public uint TotalEducationCount { get; set; }

    }
}
