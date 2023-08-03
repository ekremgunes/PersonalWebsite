using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class RemoveSocialMediaCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveSocialMediaCommand(int id)
        {
            this.Id = id;
        }
    }
}
