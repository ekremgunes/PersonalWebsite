using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        public string Title { get; set; }

    }
}
