using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateTechnologyCommand : IRequest
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string ColorCode { get; set; }
        public string Title { get; set; }
        public ushort order { get; set; }
    }
}
