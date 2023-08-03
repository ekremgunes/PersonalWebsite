using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetSettingsQueryHandler : IRequestHandler<GetSettingsQuery, GetSettingsQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetSettingsQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetSettingsQueryResult> Handle(GetSettingsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Setting>().GetQuery().FirstAsync();
            return _mapper.Map<GetSettingsQueryResult>(entity);
        }
    }
}
