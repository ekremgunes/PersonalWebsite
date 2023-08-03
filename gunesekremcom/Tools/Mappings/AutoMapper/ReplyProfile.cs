using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class ReplyProfile : Profile
    {
        public ReplyProfile()
        {
            CreateMap<CreateReplyCommand, Reply>();
            CreateMap<GetRepliesQueryResult, Reply>().ReverseMap();
        }
    }
}
