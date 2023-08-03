using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class TechnologyProfile : Profile
    {
        public TechnologyProfile()
        {
            CreateMap<GetTechnologyByIdQueryResult, Technology>().ReverseMap();
            CreateMap<GetTechnologyByIdQueryResult, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<GetTechnologiesQueryResult, Technology>().ReverseMap();
            CreateMap<CreateTechnologyCommand, Technology>().ReverseMap();
            CreateMap<UpdateTechnologyCommand, Technology>().ReverseMap();
        }
    }
}
