using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateSettingsCommand : IRequest
    {
        public string ProfilePhoto { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
        public string SchoolUrl { get; set; }
        public string Location { get; set; }
        public string AboutArticle { get; set; }

        public string? Company { get; set; }
        public string? CompanyUrl { get; set; }
        public string LogoImage { get; set; }
        public string Icon { get; set; }
    }
}
