using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetUserQuery : IRequest<GetUserQueryResult>
    {
        public string Name { get; set; }
        public GetUserQuery(string Name)
        {
            this.Name = Name;
        }
    }
}
