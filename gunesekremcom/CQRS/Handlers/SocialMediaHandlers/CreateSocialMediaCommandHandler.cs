using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateSocialMediaCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<SocialMedia>().CreateAsync(_mapper.Map<SocialMedia>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
