using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            await _uow.GetRepository<Project>().CreateAsync(_mapper.Map<Project>(request));
            await _uow.SaveChangesAsync();
        }
    }
}
