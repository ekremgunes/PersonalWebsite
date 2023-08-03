using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetTechnologyByIdQuery : IRequest<GetTechnologyByIdQueryResult>
    {
        public int Id { get; set; }
        public GetTechnologyByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
