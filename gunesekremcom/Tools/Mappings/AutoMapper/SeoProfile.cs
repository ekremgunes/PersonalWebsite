using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class SeoProfile : Profile
    {
        public SeoProfile()
        {
            CreateMap<GetSeoQueryResult, UpdateSeoCommand>().ReverseMap();
        }
    }
}
