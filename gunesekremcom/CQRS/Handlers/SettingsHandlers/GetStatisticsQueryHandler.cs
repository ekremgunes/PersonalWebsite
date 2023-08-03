using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Queries.SettingsQueries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.SettingsHandlers
{
    public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, GetStatisticsQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMediator _mediator;
        public GetStatisticsQueryHandler(IUow uow, IMediator mediator)
        {
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<GetStatisticsQueryResult> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
        {
            var result = new GetStatisticsQueryResult
            {
                SocialMediaStats = new Dictionary<string, uint>(),
                VisitorStats = new List<StatisticModel>()
            };

            //SocialMedia Stats
            var socialMedias = await _mediator.Send(new GetSocialMediasQuery(), CancellationToken.None);
            foreach (var item in socialMedias)
            {
                result.SocialMediaStats.Add(item.Name, item.ClickCount);
            }

            //Visitor Stats
            var stats = await _uow.GetRepository<Statistic>().GetAllAsync();
            stats = stats.OrderBy(x => x.Date).ToList();
            foreach (var item in stats)
            {
                result.VisitorStats.Add(new StatisticModel { date = item.Date.ToString("yyyy-MM-dd"), value = item.VisitorCount });
            }

            //visitor-project-education-post counts
            result.TotalProjectCount = (uint)await _uow.GetRepository<Project>()
                .GetQuery().CountAsync(CancellationToken.None);

            result.TotalPostCount = (uint)await _uow.GetRepository<Post>()
                .GetQuery().CountAsync(CancellationToken.None);

            result.TotalEducationCount = (uint)await _uow.GetRepository<Education>()
                .GetQuery().CountAsync(CancellationToken.None);

            result.TotalVisitorCount = _uow.GetRepository<Setting>()
                .GetQuery().First().VisitorCount;

            return result;
        }
    }
}
