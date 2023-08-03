using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetProjectByIdQuery : IRequest<GetProjectByIdQueryResult>
    {
        public int Id { get; set; }
        public GetProjectByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
