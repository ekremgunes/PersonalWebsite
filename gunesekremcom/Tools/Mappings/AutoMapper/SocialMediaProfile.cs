using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<GetSocialMediaByIdQueryResult, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<GetSocialMediaByIdQueryResult, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediasQueryResult, SocialMedia>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
        }
    }
}
