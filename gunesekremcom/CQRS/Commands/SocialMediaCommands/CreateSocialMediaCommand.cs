using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public ushort order { get; set; }
    }
}
