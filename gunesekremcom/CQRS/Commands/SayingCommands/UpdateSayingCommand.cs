using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateSayingCommand : IRequest
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Content { get; set; }
    }
}
