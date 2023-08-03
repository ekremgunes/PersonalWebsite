using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<GetSettingsQueryResult, UpdateSettingsCommand>().ReverseMap();
            CreateMap<GetSettingsQueryResult, Setting>().ReverseMap();
        }
    }
}
