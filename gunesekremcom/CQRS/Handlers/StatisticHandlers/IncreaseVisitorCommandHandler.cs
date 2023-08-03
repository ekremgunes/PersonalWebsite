using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.StatisticHandlers
{
    public class IncreaseVisitorCommandHandler : IRequestHandler<IncreaseVisitorCommand>
    {
        private readonly IUow _uow;

        public IncreaseVisitorCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task Handle(IncreaseVisitorCommand request, CancellationToken cancellationToken)
        {
            var lastDay = await _uow.GetRepository<Statistic>()
                .GetQuery()
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(CancellationToken.None); //it means today actually

            if (lastDay != null)
            {
                lastDay.VisitorCount += 1;
                await _uow.SaveChangesAsync();

            }
        }
    }
}
