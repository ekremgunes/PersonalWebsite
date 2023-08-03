using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;

namespace gunesekremcom.CQRS.Handlers
{
    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public UpdateTechnologyCommandHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.GetRepository<Technology>().GetByIdAsync(request.Id);
            if (entity != null)
            {
                var newEntity = _mapper.Map<Technology>(request);
                await _uow.GetRepository<Technology>().UpdateAsync(entity, newEntity);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
