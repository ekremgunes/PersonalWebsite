using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdatePostCommand : IRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ushort ReadingTime { get; set; }

        public int CategoryId { get; set; }
    }
}
