using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateSettingsCommandHandler : IRequestHandler<UpdateSettingsCommand>
    {
        private readonly DatabaseContext context;

        public UpdateSettingsCommandHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task Handle(UpdateSettingsCommand request, CancellationToken cancellationToken)
        {
            var settings = await context.Settings.FirstAsync();

            settings.SchoolUrl = request.SchoolUrl;
            settings.School = request.School;
            settings.Name = request.Name;
            settings.Definition = request.Definition;
            settings.CompanyUrl = request.CompanyUrl;
            settings.Company = request.Company;
            settings.Email = request.Email;
            settings.ProfilePhoto = request.ProfilePhoto;
            settings.Location = request.Location;
            settings.LogoImage = request.LogoImage;
            settings.Icon = request.Icon;
            settings.AboutArticle = request.AboutArticle;

            await context.SaveChangesAsync();
        }
    }
}
