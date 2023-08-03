using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUow _uow;

        public UpdateCategoryCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Category>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                var newEntity = new Category { Id = request.Id, Title = request.Title };
                await _uow.GetRepository<Category>().UpdateAsync(entity, newEntity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
