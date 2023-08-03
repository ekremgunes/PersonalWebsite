using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.UserHandlers
{

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUow _uow;

        public UpdateUserCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _uow.GetRepository<User>().GetByIdAsync(request.Id);
            if (user?.Password == request.Password)
            {
                if (request.NewPassword != null)
                {
                    user.Password = request.NewPassword;
                }
                user.Name = request.Name;
                user.Email = request.Email;
                await _uow.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
