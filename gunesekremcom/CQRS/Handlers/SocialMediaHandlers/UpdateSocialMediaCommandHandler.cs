using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public UpdateSocialMediaCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<SocialMedia>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                var newEntity = _mapper.Map<SocialMedia>(request);
                newEntity.ClickCount = entity.ClickCount;
                await _uow.GetRepository<SocialMedia>().UpdateAsync(entity, newEntity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
