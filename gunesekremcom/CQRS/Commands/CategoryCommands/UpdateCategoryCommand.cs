using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
