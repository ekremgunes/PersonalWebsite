using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class SayingProfile : Profile
    {
        public SayingProfile()
        {
            CreateMap<GetSayingByIdQueryResult, UpdateSayingCommand>().ReverseMap();
            CreateMap<GetSayingsQueryResult, Saying>().ReverseMap();
        }
    }
}
