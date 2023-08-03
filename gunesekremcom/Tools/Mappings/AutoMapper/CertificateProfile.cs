using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            CreateMap<GetCertificateByIdQueryResult, UpdateCertificateCommand>().ReverseMap();
            CreateMap<GetCertificateByIdQueryResult, Certificate>().ReverseMap();
            CreateMap<CreateCertificateCommand, Certificate>().ReverseMap();
            CreateMap<UpdateCertificateCommand, Certificate>().ReverseMap();
            CreateMap<GetCertificationsQueryResult, Certificate>().ReverseMap();
        }
    }
}
