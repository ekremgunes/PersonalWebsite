using gunesekremcom.CQRS.Results;
using MediatR;

namespace gunesekremcom.CQRS.Queries
{
    public class GetCertificateByIdQuery : IRequest<GetCertificateByIdQueryResult>
    {
        public int Id { get; set; }
        public GetCertificateByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
