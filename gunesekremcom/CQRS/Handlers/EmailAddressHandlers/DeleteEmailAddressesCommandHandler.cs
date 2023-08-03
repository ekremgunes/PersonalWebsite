using gunesekremcom.CQRS.Commands.EmailAddressCommands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.EmailAddressHandlers
{
    public class DeleteEmailAddressesCommandHandler : IRequestHandler<DeleteEmailAddressesCommand>
    {
        private readonly IUow _uow;
        public DeleteEmailAddressesCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task Handle(DeleteEmailAddressesCommand request, CancellationToken cancellationToken)
        {
            List<EmailAddress> mails = new();
            if (request.MailIds.Length == 0) //send to all subs
            {
                mails = await _uow.GetRepository<EmailAddress>().GetAllAsync();

            }
            else
            {
                mails = await _uow.GetRepository<EmailAddress>().GetQuery()
                     .Where(x => request.MailIds.Contains(x.Id))
                     .ToListAsync();
            }
            if (mails.Count > 0)
            {
                var repo = _uow.GetRepository<EmailAddress>();

                foreach (var item in mails)
                {
                    await repo.RemoveAsync(item);
                }
                await _uow.SaveChangesAsync();
            }
        }
    }
}
