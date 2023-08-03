using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreateSayingCommand : IRequest
    {
        public string Owner { get; set; }
        public string Content { get; set; }
    }
}
