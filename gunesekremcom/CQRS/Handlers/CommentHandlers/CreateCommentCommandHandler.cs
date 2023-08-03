using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public CreateCommentCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Comment>().CreateAsync(_mapper.Map<Comment>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
