using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateSeoCommandHandler : IRequestHandler<UpdateSeoCommand>
    {
        private readonly IUow _uow;

        public UpdateSeoCommandHandler(IUow uow)
        {
            _uow = uow;
        }

        public async Task Handle(UpdateSeoCommand request, CancellationToken cancellationToken)
        {
            var seoEntity = _uow.GetRepository<Seo>().GetQuery().First();
            seoEntity.SeoHTML = request.SeoHTML;
            await _uow.SaveChangesAsync();
        }
    }
}
