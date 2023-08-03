using gunesekremcom.CQRS.Results;

namespace gunesekremcom.ViewModels
{
    public class PortfolioViewModel
    {
        public GetSettingsQueryResult Settings { get; set; }
        public List<GetTechnologiesQueryResult>? Technologies { get; set; }
        public List<GetCertificationsQueryResult>? Certifications { get; set; }
        public List<GetSocialMediasQueryResult>? SocialMedias { get; set; }
    }
}
