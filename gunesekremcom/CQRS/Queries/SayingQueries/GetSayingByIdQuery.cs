using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetSayingByIdQuery : IRequest<GetSayingByIdQueryResult>
    {
        public int Id { get; set; }
        public GetSayingByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
