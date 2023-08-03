using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateTechnologyCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Technology>().CreateAsync(_mapper.Map<Technology>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
