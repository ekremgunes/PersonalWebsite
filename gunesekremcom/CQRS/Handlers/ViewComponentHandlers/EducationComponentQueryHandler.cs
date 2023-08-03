using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.ViewComponentHandlers
{
    public class EducationComponentQueryHandler : IRequestHandler<EducationComponentQuery, List<EducationComponentQueryResult>>
    {
        private readonly IUow _uow;

        public EducationComponentQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<List<EducationComponentQueryResult>> Handle(EducationComponentQuery request, CancellationToken cancellationToken)
        {
            short educationCount = 4;
            var educations = await _uow.GetRepository<Education>().GetQuery()
                .OrderBy(x => x.Order)
                .Take(educationCount)
                .Select(x => new EducationComponentQueryResult
                {
                    Order = x.Order,
                    Definition = x.Definition,
                    Slug = x.Slug,
                    Title = x.Title,
                    Id = x.Id,
                    Image = x.Image,
                    StudentCount = x.StudentCount,
                    ViewCount = x.ViewCount
                })
                .ToListAsync();

            return educations;
        }
    }
}
