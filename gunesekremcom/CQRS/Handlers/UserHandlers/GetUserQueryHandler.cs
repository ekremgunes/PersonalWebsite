using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetUserQueryResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _uow.GetRepository<User>().GetQuery()
                .FirstOrDefaultAsync(x => x.Name == request.Name);
            var result = new GetUserQueryResult();
            if (user != null)
            {
                result = _mapper.Map<GetUserQueryResult>(user);
            }
            return result;
        }
    }
}
