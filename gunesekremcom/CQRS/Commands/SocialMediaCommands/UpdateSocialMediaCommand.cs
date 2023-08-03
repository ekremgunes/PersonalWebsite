using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public ushort order { get; set; }
    }
}
