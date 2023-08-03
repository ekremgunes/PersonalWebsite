using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Tools;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateEducationCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Education>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                var newEntity = _mapper.Map<Education>(request);
                newEntity.Slug = entity.Slug;

                if (entity.Title != request.Title)
                {
                    newEntity.Slug = await SlugMaker.Make(request.Title);
                }
                await _uow.GetRepository<Education>().UpdateAsync(entity, newEntity);
                await _uow.SaveChangesAsync();
            }

        }
    }
}
