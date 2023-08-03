using AutoMapper;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class EmailAdressProfile : Profile
    {
        public EmailAdressProfile()
        {
            CreateMap<EmailAddress, GetEmailAddressesQueryResult>().ReverseMap();
        }
    }
}
