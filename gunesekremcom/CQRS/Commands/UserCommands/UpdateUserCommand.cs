using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? NewPassword { get; set; }
    }
}
