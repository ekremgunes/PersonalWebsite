using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveCertificateCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveCertificateCommand(int id)
        {
            this.Id = id;
        }
    }
}
