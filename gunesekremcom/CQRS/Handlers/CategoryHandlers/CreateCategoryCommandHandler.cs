using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IUow _uow;

        public CreateCategoryCommandHandler(IUow _uow)
        {
            this._uow = _uow;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Category>().CreateAsync(new Category
            {
                Title = request.Title
            });
            await _uow.SaveChangesAsync();
        }
    }
}
