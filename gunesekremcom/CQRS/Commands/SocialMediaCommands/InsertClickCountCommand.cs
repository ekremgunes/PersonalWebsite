using MediatR;

namespace gunesekremcom.CQRS.Commands.SocialMediaCommands
{
    public class InsertClickCountCommand : IRequest
    {
        public int Id { get; set; }
        public InsertClickCountCommand(int id)
        {
            this.Id = id;
        }
    }
}
