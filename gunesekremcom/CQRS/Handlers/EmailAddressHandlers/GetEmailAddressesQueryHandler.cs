using AutoMapper;
using gunesekremcom.CQRS.Queries.EmailAddressQueries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.EmailAddressHandlers
{
    public class GetEmailAddressesQueryHandler : IRequestHandler<GetEMailAddressesQuery, List<GetEmailAddressesQueryResult>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetEmailAddressesQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<List<GetEmailAddressesQueryResult>> Handle(GetEMailAddressesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _uow.GetRepository<EmailAddress>().GetAllAsync();
            return _mapper.Map<List<GetEmailAddressesQueryResult>>(entities);
        }
    }
}
