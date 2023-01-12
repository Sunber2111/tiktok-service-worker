using Application.Posts.DTO;
using AutoMapper;
using Domain;

namespace Application.Posts.Mapper
{
    public class PostMapper : Profile
    {
        public PostMapper()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}

