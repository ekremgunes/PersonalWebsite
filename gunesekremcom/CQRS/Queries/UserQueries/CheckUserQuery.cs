using gunesekremcom.CQRS.Results.UserResults;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class CheckUserQuery : IRequest<CheckUserQueryResult>
    {

        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
