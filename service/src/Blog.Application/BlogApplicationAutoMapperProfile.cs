using AutoMapper;
using Blog.Users;

namespace Blog
{
    public class BlogApplicationAutoMapperProfile : Profile
    {
        public BlogApplicationAutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
