using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Context;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IUow _uow;
        private readonly DatabaseContext context;

        public RemoveCategoryCommandHandler(IUow _uow, DatabaseContext context)
        {
            this._uow = _uow;
            this.context = context;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryCount = context.Categories.Count();
            if (categoryCount == 1) //one category is required
            {
                return;
            }
            var entity = await _uow.GetRepository<Category>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _uow.GetRepository<Category>().RemoveAsync(entity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
