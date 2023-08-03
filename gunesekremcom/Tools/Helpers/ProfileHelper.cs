
using AutoMapper;
using gunesekremcom.Tools.Mappings.AutoMapper;

namespace gunesekremcom.Tools.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {

            return new List<Profile>
            {
                new CategoryProfile(),
                new CertificateProfile(),
                new PostProfile(),
                new SayingProfile(),
                new SeoProfile(),
                new SettingsProfile(),
                new SocialMediaProfile(),
                new UserProfile(),
                new CommentProfile(),
                new ReplyProfile(),
                new TechnologyProfile(),
                new ProjectProfile(),
                new EducationProfile(),
                new EmailAdressProfile()
            };
        }
    }
}
