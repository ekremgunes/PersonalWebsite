using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreatePostCommand : IRequest
    {
        public string Slug { get; set; }
        public string? Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public uint ViewCount { get; set; }
        public ushort ReadingTime { get; set; }
        public int CategoryId { get; set; }
    }
}
