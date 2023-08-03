using AutoMapper;
using gunesekremcom.CQRS.Queries;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Iuow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace gunesekremcom.CQRS.Handlers
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdQueryResult>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IUow _uow, IMapper mapper)
        {
            this._uow = _uow;
            _mapper = mapper;
        }

        public async Task<GetPostByIdQueryResult> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new GetPostByIdQueryResult();
            var entity = await _uow.GetRepository<Post>().GetQuery()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity != null)
            {

                result = _mapper.Map<GetPostByIdQueryResult>(entity);
            }
            return result;
        }
    }
}
