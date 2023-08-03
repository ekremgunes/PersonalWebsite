using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using gunesekremcom.Tools;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Post>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                var newEntity = _mapper.Map<Post>(request);
                newEntity.Slug = entity.Slug;
                newEntity.Date = entity.Date;
                newEntity.ViewCount = entity.ViewCount;
                if (entity.Title != request.Title)
                {
                    newEntity.Slug = await SlugMaker.Make(request.Title);
                }
                await _uow.GetRepository<Post>().UpdateAsync(entity, newEntity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
