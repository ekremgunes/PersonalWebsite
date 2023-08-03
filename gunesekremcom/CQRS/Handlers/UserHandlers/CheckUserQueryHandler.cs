using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results.UserResults;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.UserHandlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, CheckUserQueryResult>
    {
        private readonly IUow _uow;

        public CheckUserQueryHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task<CheckUserQueryResult> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _uow.GetRepository<User>()
                .GetQuery()
                .FirstOrDefaultAsync(x => x.Name == request.Name && x.Password == request.Password);

            var result = new CheckUserQueryResult();
            result.IsExist = false;

            if (user != null)
            {
                result.Id = user.Id;
                result.Name = user.Name;
                result.Email = user.Email;
                result.IsExist = true;
            }

            return result;
        }
    }
}
