using MediatR;

namespace gunesekremcom.CQRS.Commands
{
    public class SendEmailsCommand : IRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public int[] MailIds { get; set; }
    }
}
