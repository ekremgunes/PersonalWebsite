using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Post>().CreateAsync(_mapper.Map<Post>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
