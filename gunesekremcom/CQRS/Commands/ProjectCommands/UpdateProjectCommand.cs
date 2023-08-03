using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateProjectCommand : IRequest
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public string? Url { get; set; }
        public ushort Order { get; set; }

        public string Content { get; set; }
        public ushort Star { get; set; }
    }
}
