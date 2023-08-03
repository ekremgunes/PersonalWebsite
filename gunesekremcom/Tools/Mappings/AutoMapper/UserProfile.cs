using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.CQRS.Results.UserResults;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserQueryResult>().ReverseMap();
            CreateMap<UpdateUserCommand, GetUserQueryResult>().ReverseMap();
            CreateMap<UpdateUserCommand, CheckUserQueryResult>().ReverseMap();
        }
    }
}
