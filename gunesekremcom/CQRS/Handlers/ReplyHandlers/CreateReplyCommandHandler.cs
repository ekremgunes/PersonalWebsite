using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers.ReplyHandlers
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateReplyCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Reply>().CreateAsync(_mapper.Map<Reply>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
