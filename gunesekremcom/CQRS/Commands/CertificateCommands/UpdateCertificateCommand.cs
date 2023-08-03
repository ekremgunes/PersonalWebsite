using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateCertificateCommand : IRequest
    {
        public int Id { get; set; }
        public string CredentialUrl { get; set; }
        public string Title { get; set; }
        public ushort order { get; set; }
        public string Host { get; set; }
        public string Image { get; set; }
    }
}
