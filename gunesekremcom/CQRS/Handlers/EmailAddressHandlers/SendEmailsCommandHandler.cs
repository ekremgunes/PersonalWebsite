using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Tools.EmailService;
using gunesekremcom.Tools.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers.EmailAddressHandlers
{
    public class SendEmailsCommandHandler : IRequestHandler<SendEmailsCommand>
    {
        private readonly IUow _uow;
        private readonly IEmailService _emailService;

        public SendEmailsCommandHandler(IUow uow, IEmailService emailService)
        {
            _uow = uow;
            _emailService = emailService;
        }

        public async Task Handle(SendEmailsCommand request, CancellationToken cancellationToken)
        {
            List<EmailAddress> mails = new();
            if (request.MailIds.Length == 0) //send to all subs
            {
                mails = await _uow.GetRepository<EmailAddress>().GetAllAsync();
                mails = mails.Where(x => x.isConfirmed == true).ToList();
            }
            else
            {
                mails = await _uow.GetRepository<EmailAddress>().GetQuery()
                     .Where(x => x.isConfirmed == true)
                     .Where(x => request.MailIds.Contains(x.Id))
                     .ToListAsync(CancellationToken.None);
            }
            ushort sendCount = 0;
            foreach (var item in mails)
            {
                try
                {
                    await _emailService.SendEmail(item.Email, request.Subject, request.Body);
                    sendCount++;
                }
                catch (Exception)
                {
                    LogHelper.Log("Toplu Mail Gönderilirken sorun oluştu , sorun oluşan mail : " + item.Email, null, null);
                }
            }
            LogHelper.Log($"{mails.Count}/{sendCount} Mail Gönderildi ", null, null);


        }
    }
}
