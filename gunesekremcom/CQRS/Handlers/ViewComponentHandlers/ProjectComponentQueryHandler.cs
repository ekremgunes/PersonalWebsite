using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class ProjectComponentQueryHandler : IRequestHandler<ProjectComponentQuery, List<ProjectComponentQueryResult>>
    {
        private readonly IUow _uow;

        public ProjectComponentQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<List<ProjectComponentQueryResult>> Handle(ProjectComponentQuery request, CancellationToken cancellationToken)
        {
            short projectCount = 4;

            var projects = await _uow.GetRepository<Project>().GetQuery()
                .OrderBy(x => x.Order)
                .Take(projectCount)
                .Select(x => new ProjectComponentQueryResult
                {
                    Order = x.Order,
                    Id = x.Id,
                    Image = x.Image,
                    Slug = x.Slug,
                    Star = x.Star,
                    Title = x.Title
                })
                .ToListAsync();

            return projects;
        }
    }
}
