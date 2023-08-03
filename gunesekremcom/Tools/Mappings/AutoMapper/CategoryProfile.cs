using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<GetCategoryByIdQueryResult, UpdateCategoryCommand>().ReverseMap();
        }
    }
}
