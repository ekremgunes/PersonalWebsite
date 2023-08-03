using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveCategoryCommand(int id)
        {
            this.Id = id;
        }
    }
}
