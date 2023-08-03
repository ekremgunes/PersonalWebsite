using AutoMapper;
using gunesekremcom.CQRS.Commands;
using gunesekremcom.CQRS.Results;
using gunesekremcom.Data.Entities;

namespace gunesekremcom.Tools.Mappings.AutoMapper
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<GetPostByIdQueryResult, UpdatePostCommand>().ReverseMap();
            CreateMap<GetPostByIdQueryResult, Post>().ReverseMap();
            CreateMap<LoadMorePostQueryResult, Post>().ReverseMap();
            CreateMap<GetPostsQueryResult, Post>().ReverseMap();
            CreateMap<CreatePostCommand, Post>().ReverseMap();
            CreateMap<UpdatePostCommand, Post>().ReverseMap();
        }
    }
}
