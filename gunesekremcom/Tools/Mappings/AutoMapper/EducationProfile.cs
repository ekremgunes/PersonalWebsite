using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<Education, CreateEducationCommand>().ReverseMap();
            CreateMap<Education, UpdateEducationCommand>().ReverseMap();
            CreateMap<Education, GetEducationsQueryResult>().ReverseMap();
            CreateMap<Education, GetEducationByIdQueryResult>().ReverseMap();
            CreateMap<Education, GetEducationBySlugQueryResult>().ReverseMap();
        }
    }
}
