using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetPostByIdQuery : IRequest<GetPostByIdQueryResult>
    {
        public int Id { get; set; }
        public GetPostByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
