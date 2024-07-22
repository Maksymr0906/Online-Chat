using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.User;

namespace OnlineChat.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequestDto, User>();
            CreateMap<UpdateUserRequestDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
