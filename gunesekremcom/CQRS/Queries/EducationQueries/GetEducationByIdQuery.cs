using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetEducationByIdQuery : IRequest<GetEducationByIdQueryResult>
    {
        public int Id { get; set; }
        public GetEducationByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
