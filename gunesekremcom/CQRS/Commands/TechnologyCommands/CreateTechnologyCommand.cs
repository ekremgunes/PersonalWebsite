using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreateTechnologyCommand : IRequest
    {
        public string Icon { get; set; }
        public string ColorCode { get; set; }
        public string Title { get; set; }
        public ushort order { get; set; }
    }
}
