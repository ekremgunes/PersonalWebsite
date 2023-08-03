using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateSeoCommand : IRequest
    {
        public string SeoHTML { get; set; }
    }
}
