using AutoMapper;
using OnlineChat.Models.Domain;
using OnlineChat.Models.Dto.User;

namespace OnlineChat.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequestDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UpdateUserRequestDto, User>()
                .ForMember(dest => dest.CreatedChats, opt => opt.Ignore())
                .ForMember(dest => dest.ParticipatingChats, opt => opt.Ignore())
                .ForMember(dest => dest.Messages, opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.CreatedChatIds, opt => opt.MapFrom(src => src.CreatedChats.Select(c => c.Id)))
                .ForMember(dest => dest.ParticipatingChatIds, opt => opt.MapFrom(src => src.ParticipatingChats.Select(c => c.Id)))
                .ForMember(dest => dest.MessageIds, opt => opt.MapFrom(src => src.Messages.Select(m => m.Id)));
        }
    }
}
