using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Tools;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Project>().GetByIdAsync(request.Id);
            if (entity != null)
            {

                var newEntity = _mapper.Map<Project>(request);
                newEntity.Slug = entity.Slug;
                if (entity.Title != request.Title)
                {
                    newEntity.Slug = await SlugMaker.Make(request.Title);
                }
                await _uow.GetRepository<Project>().UpdateAsync(entity, newEntity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
