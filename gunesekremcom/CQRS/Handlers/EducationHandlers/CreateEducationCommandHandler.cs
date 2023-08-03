using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateEducationCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Education>().CreateAsync(_mapper.Map<Education>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
